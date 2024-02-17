using Library.Data;
using Library.Interfaces;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers;

[Authorize]
public class BooksController:Controller
{
    private readonly LibraryDbContext dbContext;
    private readonly IBookService bookService;

    public BooksController(LibraryDbContext dbContext,IBookService bookService)
    {
        this.dbContext = dbContext;
        this.bookService = bookService;
    }

    public async Task<IActionResult> All()
    {
        var bookViewModels = await bookService.GetAllBooksAsync();

        return View(bookViewModels);
    }
    public async Task<IActionResult> Add()
    {
        var bookViewModel = new FormBookViewModel();

        bookViewModel.Categories = await bookService.GetCategoriesAsync();

        return View(bookViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Add(FormBookViewModel bookViewModel)
    {
        bool isValidId = await bookService.DoesCategoryExistAsync(bookViewModel.CategoryId);

        if(isValidId == false)
        {
            ModelState.AddModelError("CategoryId","Invalid Category Id!");
        }

        if(ModelState.IsValid == false)
        {
            bookViewModel.Categories = await bookService.GetCategoriesAsync();

            return View(bookViewModel);
        }

        await bookService.AddAsync(bookViewModel);

        return RedirectToAction(nameof(All));
    }
    public async Task<IActionResult> AddToCollection(int bookId)
    {
        string userId = GetUserId();

        await bookService.AddBookToCollectionAsync(userId,bookId);

        return RedirectToAction(nameof(All));
    }
    public async Task<IActionResult> Mine()
    {
        string userId = GetUserId();

        var myBooks = await bookService.GetAllMineBooksAsync(userId);

        return View(myBooks);
    }
    public async Task<IActionResult> RemoveFromCollection(int bookId)
    {
        string userId = GetUserId();

        if(await bookService.RemoveFromCollectionAsync(userId,bookId) == false)
        {
            return RedirectToAction(nameof(All));
        }

        return RedirectToAction(nameof(Mine));
    }
    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
