using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models.AdModels;
using SoftUniBazar.Models.CategoryModels;
using System.Security.Claims;

namespace SoftUniBazar.Controllers;

[Authorize]
public class AdController:Controller
{
    private readonly BazarDbContext dbContext;

    public AdController(BazarDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IActionResult> All()
    {
        var ads = await dbContext.Ads
            .Select(a => new AllAdViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                ImageUrl = a.ImageUrl,
                CreatedOn = a.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                Category = a.Category.Name,
                Description = a.Description,
                Price = a.Price,
                Owner = a.Owner.UserName
            })
            .AsNoTracking()
            .ToArrayAsync();

        return View(ads);
    }
    public async Task<IActionResult> Add()
    {
        AdFormViewModel model = new();

        model.Categories = await GetCategoriesAsync();

        return View(model);
    }
    private async Task<CategoryViewModel[]> GetCategoriesAsync()
    {
        CategoryViewModel[] categories = await dbContext.Categories
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .AsNoTracking()
            .ToArrayAsync();

        return categories;
    }
    [HttpPost]
    public async Task<IActionResult> Add(AdFormViewModel model)
    {
        bool categoryExists = dbContext.Categories
            .Any(c => model.CategoryId == c.Id);

        if(categoryExists == false)
        {
            ModelState.AddModelError(nameof(model.CategoryId),"Category Not Found!");
        }

        if(ModelState.IsValid == false)
        {
            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        Ad ad = new Ad()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            OwnerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            ImageUrl = model.ImageUrl,
            CreatedOn = DateTime.Now,
            CategoryId = model.CategoryId
        };

        await dbContext.Ads.AddAsync(ad);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var adToEdit = await dbContext.Ads.FindAsync(id);

        if(adToEdit == null)
        {
            return BadRequest();
        }

        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(currentUserId != adToEdit.OwnerId)
        {
            return Unauthorized();
        }

        AdFormViewModel adModel = new AdFormViewModel()
        {
            Name = adToEdit.Name,
            Description = adToEdit.Description,
            Price = adToEdit.Price,
            CategoryId = adToEdit.CategoryId,
            Categories = await GetCategoriesAsync(),
            ImageUrl = adToEdit.ImageUrl
        };

        return View(adModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,AdFormViewModel adModel)
    {
        var adToEdit = await dbContext.Ads.FindAsync(id);

        if(adToEdit == null)
        {
            return BadRequest();
        }

        string currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(currentUser != adToEdit.OwnerId)
        {
            return Unauthorized();
        }

        bool categoryExists = dbContext.Categories
            .Any(c => adToEdit.CategoryId == c.Id);

        if(categoryExists == false)
        {
            ModelState.AddModelError(nameof(adToEdit.CategoryId),"Category Not Found!");
        }

        adToEdit.Name = adModel.Name;
        adToEdit.Description = adModel.Description;
        adToEdit.Price = adModel.Price;
        adToEdit.CategoryId = adModel.CategoryId;
        adToEdit.ImageUrl = adModel.ImageUrl;

        await dbContext.SaveChangesAsync();

        return RedirectToAction("All","Ad");
    }

    public async Task<IActionResult> Cart()
    {
        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var userAds = await dbContext
            .AdsBuyers
            .Where(ab => ab.BuyerId == currentUserId)
            .Select(ab => new AllAdViewModel()
            {
                Id = ab.Ad.Id,
                Name = ab.Ad.Name,
                Description = ab.Ad.Description,
                CreatedOn = ab.Ad.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                Category = ab.Ad.Category.Name,
                Price = ab.Ad.Price,
                ImageUrl = ab.Ad.ImageUrl,
                Owner = ab.Ad.Owner.UserName
            })
            .ToListAsync();

        return View(userAds);
    }

    public async Task<IActionResult> AddToCart(int id)
    {
        var adToAdd = await dbContext.Ads
            .FindAsync(id);

        if(adToAdd == null)
        {
            return BadRequest();
        }

        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        bool alreadyExist = await dbContext.AdsBuyers
            .AnyAsync(ab => ab.BuyerId == currentUserId && ab.AdId == adToAdd.Id);

        if(alreadyExist)
        {
            return RedirectToAction("Cart","Ad");
        }

        var entry = new AdBuyer()
        {
            AdId = adToAdd.Id,
            BuyerId = currentUserId,
        };

        await dbContext.AdsBuyers.AddAsync(entry);
        await dbContext.SaveChangesAsync();

        return RedirectToAction("Cart","Ad");
    }

    public async Task<IActionResult> RemoveFromCart(int id)
    {
        var currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var entry = await dbContext.AdsBuyers
            .FirstOrDefaultAsync(ab => ab.BuyerId == currentUser && ab.AdId == id);

        if(entry == null)
        {
            return BadRequest();
        }

        dbContext.AdsBuyers.Remove(entry);

        await dbContext.SaveChangesAsync();

        return RedirectToAction("All","Ad");
    }
}
