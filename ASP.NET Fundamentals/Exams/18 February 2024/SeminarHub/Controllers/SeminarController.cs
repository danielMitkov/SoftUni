using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers;

[Authorize]
public class SeminarController:Controller
{
    private readonly SeminarHubDbContext dbContext;

    public SeminarController(SeminarHubDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> All()
    {
        AllSeminarViewModel[] seminars = await dbContext.Seminars
            .AsNoTracking()
            .Select(s => new AllSeminarViewModel()
            {
                Id = s.Id,
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Category = s.Category.Name,
                DateAndTime = s.DateAndTime.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
                Organizer = s.Organizer.UserName
            })
            .ToArrayAsync();

        return View(seminars);
    }
    public async Task<IActionResult> Add()
    {
        FormSeminarViewModel seminarModel = new FormSeminarViewModel();

        seminarModel.Categories = await GetCategoriesAsync();

        return View(seminarModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(FormSeminarViewModel seminarModel)
    {
        int[] categoryIds = (await GetCategoriesAsync())
            .Select(c => c.Id)
            .ToArray();

        if(categoryIds.Contains(seminarModel.CategoryId) == false)
        {
            ModelState.AddModelError("CategoryId","Category does not exist!");
        }

        bool isValidDate = DateTime.TryParseExact(seminarModel.DateAndTime,
            "dd/MM/yyyy HH:mm",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime dateAndTime);

        if(isValidDate == false)
        {
            ModelState.AddModelError("DateAndTime","Date Format is incorrect!");
        }

        if(ModelState.IsValid == false)
        {
            seminarModel.Categories = await GetCategoriesAsync();

            return View(seminarModel);
        }

        Seminar seminar = new Seminar()
        {
            Topic = seminarModel.Topic,
            Lecturer = seminarModel.Lecturer,
            Details = seminarModel.Details,
            DateAndTime = dateAndTime,
            Duration = seminarModel.Duration,
            CategoryId = seminarModel.CategoryId,
            OrganizerId = GetUserId()
        };

        await dbContext.Seminars.AddAsync(seminar);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    public async Task<IActionResult> Details(int id)
    {
        Seminar? seminar = await dbContext.Seminars
            .AsNoTracking()
            .Include(s => s.Category)
            .Include(s => s.Organizer)
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seminar == null)
        {
            return RedirectToAction(nameof(All));
        }

        DetailsSeminarViewModel detailsSeminar = new DetailsSeminarViewModel()
        {
            Id = seminar.Id,
            Topic = seminar.Topic,
            DateAndTime = seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
            Duration = seminar.Duration,
            Lecturer = seminar.Lecturer,
            Category = seminar.Category.Name,
            Details = seminar.Details,
            Organizer = seminar.Organizer.UserName
        };

        return View(detailsSeminar);
    }

    public async Task<IActionResult> Edit(int id)
    {
        Seminar? seminar = await dbContext.Seminars
            .AsNoTracking()
            .Include(s => s.Category)
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seminar == null)
        {
            return RedirectToAction(nameof(All));
        }

        string userId = GetUserId();

        if(userId != seminar.OrganizerId)
        {
            return RedirectToAction(nameof(All));
        }

        FormSeminarViewModel seminarViewModel = new FormSeminarViewModel()
        {
            Id = seminar.Id,
            Topic = seminar.Topic,
            Lecturer = seminar.Lecturer,
            Details = seminar.Details,
            DateAndTime = seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
            Duration = seminar.Duration,
            CategoryId = seminar.CategoryId,
            Categories = await GetCategoriesAsync()
        };

        return View(seminarViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id,FormSeminarViewModel model)
    {
        Seminar? seminar = await dbContext.Seminars
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seminar == null)
        {
            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        string userId = GetUserId();

        if(userId != seminar.OrganizerId)
        {
            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        int[] categoryIds = (await GetCategoriesAsync())
            .Select(c => c.Id)
            .ToArray();

        if(categoryIds.Contains(model.CategoryId) == false)
        {
            ModelState.AddModelError("CategoryId","Category does not exist!");
        }

        bool isValidDate = DateTime.TryParseExact(model.DateAndTime,
            "dd/MM/yyyy HH:mm",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime dateAndTime);

        if(isValidDate == false)
        {
            ModelState.AddModelError("DateAndTime","Date Format is incorrect!");
        }

        if(ModelState.IsValid == false)
        {
            model.Categories = await GetCategoriesAsync();

            return View(model);
        }

        seminar.Topic = model.Topic;
        seminar.Lecturer = model.Lecturer;
        seminar.Details = model.Details;
        seminar.DateAndTime = dateAndTime;
        seminar.Duration = model.Duration;
        seminar.CategoryId = model.CategoryId;

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }
    public async Task<IActionResult> Join(int id)
    {
        Seminar? seminar = await dbContext.Seminars
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seminar == null)
        {
            return RedirectToAction(nameof(All));
        }

        string userId = GetUserId();

        if(userId == seminar.OrganizerId)
        {
            return RedirectToAction(nameof(All));
        }

        bool alreadyJoined = await dbContext.SeminarsParticipants
            .AnyAsync(sp => sp.ParticipantId == userId && sp.SeminarId == seminar.Id);

        if(alreadyJoined)
        {
            return RedirectToAction(nameof(All));
        }

        SeminarParticipant seminarEntry = new SeminarParticipant()
        {
            SeminarId = seminar.Id,
            ParticipantId = userId
        };

        await dbContext.SeminarsParticipants.AddAsync(seminarEntry);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Joined));
    }
    public async Task<IActionResult> Joined()
    {
        string userId = GetUserId();

        JoinedSeminarViewModel[] joinedModels = await dbContext.SeminarsParticipants
            .AsNoTracking()
            .Where(sp => sp.ParticipantId == userId)
            .Select(sp => new JoinedSeminarViewModel()
            {
                Id = sp.Seminar.Id,
                Topic = sp.Seminar.Topic,
                Lecturer = sp.Seminar.Lecturer,
                DateAndTime = sp.Seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
                Organizer = sp.Seminar.Organizer.UserName
            })
            .ToArrayAsync();

        return View(joinedModels);
    }
    public async Task<IActionResult> Leave(int id)
    {
        string userId = GetUserId();

        SeminarParticipant? seminarParticipant = await dbContext.SeminarsParticipants
            .FirstOrDefaultAsync(sp => sp.SeminarId == id && sp.ParticipantId == userId);

        if(seminarParticipant == null)
        {
            return RedirectToAction(nameof(All));
        }

        dbContext.Remove(seminarParticipant);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Joined));
    }
    public async Task<IActionResult> Delete(int id)
    {
        Seminar? seminar = await dbContext.Seminars
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seminar == null)
        {
            return RedirectToAction(nameof(All));
        }

        string userId = GetUserId();

        if(userId != seminar.OrganizerId)
        {
            return RedirectToAction(nameof(All));
        }

        DeleteSeminarViewModel deleteModel = new DeleteSeminarViewModel()
        {
            Id = seminar.Id,
            Topic = seminar.Topic,
            DateAndTime = seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture)
        };

        return View(deleteModel);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Seminar? seminar = await dbContext.Seminars
            .FirstOrDefaultAsync(s => s.Id == id);

        if(seminar == null)
        {
            return RedirectToAction(nameof(All));
        }

        string userId = GetUserId();

        if(userId != seminar.OrganizerId)
        {
            return RedirectToAction(nameof(All));
        }

        SeminarParticipant[] seminarParticipants = await dbContext.SeminarsParticipants
            .Where(sp => sp.SeminarId == id)
            .ToArrayAsync();

        dbContext.SeminarsParticipants.RemoveRange(seminarParticipants);

        dbContext.Seminars.Remove(seminar);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }
    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    private async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
    {
        return await dbContext.Categories
            .AsNoTracking()
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArrayAsync();
    }
}
