using Library.Data;
using Library.Data.Models;
using Library.Interfaces;
using Library.Models.Book;
using Library.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace Library.Services;

public class BookService:IBookService
{
    private readonly LibraryDbContext dbContext;

    public BookService(LibraryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
    {
        return await dbContext.Books
            .Select(b => new AllBookViewModel()
            {
                Id = b.Id,
                ImageUrl = b.ImageUrl,
                Title = b.Title,
                Author = b.Author,
                Rating = b.Rating,
                Category = b.Category.Name
            })
            .AsNoTracking()
            .ToArrayAsync();
    }
    public async Task<ICollection<CategoryViewModel>> GetCategoriesAsync()
    {
        return await dbContext.Categories
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .AsNoTracking()
            .ToArrayAsync();
    }
    public async Task<bool> DoesCategoryExistAsync(int categoryId)
    {
        var category = await dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == categoryId);

        return category != null ? true : false;
    }
    public async Task AddAsync(FormBookViewModel bookViewModel)
    {
        Book book = new Book()
        {
            Title = bookViewModel.Title,
            Author = bookViewModel.Author,
            Description = bookViewModel.Description,
            ImageUrl = bookViewModel.ImageUrl,
            Rating = bookViewModel.Rating,
            CategoryId = bookViewModel.CategoryId
        };

        await dbContext.Books.AddAsync(book);

        await dbContext.SaveChangesAsync();
    }
    public async Task<bool> AddBookToCollectionAsync(string userId,int bookId)
    {
        if(await DoesBookExistAsync(bookId) == false)
        {
            return false;
        }

        if(await IsBookAlreadyAddedAsync(userId,bookId) == true)
        {
            return false;
        }

        ApplicationUserBook newEntry = new ApplicationUserBook()
        {
            BookId = bookId,
            ApplicationUserId = userId
        };

        await dbContext.ApplicationUserBooks.AddAsync(newEntry);
        await dbContext.SaveChangesAsync();

        return true;
    }
    public async Task<IEnumerable<MineBookViewModel>> GetAllMineBooksAsync(string userId)
    {
        return await dbContext.ApplicationUserBooks
            .AsNoTracking()
            .Where(a => a.ApplicationUserId == userId)
            .Select(a => new MineBookViewModel()
            {
                Id = a.Book.Id,
                ImageUrl = a.Book.ImageUrl,
                Title = a.Book.Title,
                Author = a.Book.Author,
                Description = a.Book.Description,
                Category = a.Book.Category.Name
            })
            .ToArrayAsync();
    }
    public async Task<bool> RemoveFromCollectionAsync(string userId,int bookId)
    {
        var book = await dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if(book == null)
        {
            return false;
        }

        var bookEntry = await dbContext.ApplicationUserBooks
            .FirstOrDefaultAsync(a => a.ApplicationUserId == userId && a.BookId == book.Id);

        if(bookEntry == null)
        {
            return false;
        }

        dbContext.ApplicationUserBooks.Remove(bookEntry);
        await dbContext.SaveChangesAsync();

        return true;
    }
    private async Task<bool> DoesBookExistAsync(int bookId)
    {
        Book? book = await dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == bookId);

        return book != null ? true : false;
    }
    private async Task<bool> IsBookAlreadyAddedAsync(string userId,int bookId)
    {
        return await dbContext.ApplicationUserBooks
            .AnyAsync(a => a.ApplicationUserId == userId && a.BookId == bookId);
    }
}
