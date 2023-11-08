namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.Data.SqlClient.Server;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(bc => bc.Book.ReleaseDate)
                        .Take(3)
                        .Select(bc => new
                        {
                            bc.Book.Title,
                            bc.Book.ReleaseDate.Value.Year
                        })
                })
                .ToArray()
                .OrderBy(c => c.Name);

            StringBuilder sb = new();

            foreach(var category in categoriesRecentBooks)
            {
                sb.AppendLine($"--{category.Name}");

                foreach(var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
