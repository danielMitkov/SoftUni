using Library.Models.Book;
using Library.Models.Category;

namespace Library.Interfaces;

public interface IBookService
{
    Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
    Task<ICollection<CategoryViewModel>> GetCategoriesAsync();
    Task<bool> DoesCategoryExistAsync(int categoryId);
    Task AddAsync(FormBookViewModel bookViewModel);
    Task<bool> AddBookToCollectionAsync(string userId,int bookId);
    Task<IEnumerable<MineBookViewModel>> GetAllMineBooksAsync(string userId);
    Task<bool> RemoveFromCollectionAsync(string userId,int bookId);
}
