namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.Data.SqlClient.Server;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByAuthor(db,Console.ReadLine()));
        }
        public static string GetBooksByAuthor(BookShopContext context,string input)
        {
            var booksAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                });
            return string.Join(Environment.NewLine,booksAuthors.Select(b => $"{b.Title} ({b.FirstName} {b.LastName})"));
        }
    }
}
