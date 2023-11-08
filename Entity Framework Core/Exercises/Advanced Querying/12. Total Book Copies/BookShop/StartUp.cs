namespace BookShop
{
    using BookShop.Models;
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

            Console.WriteLine(CountCopiesByAuthor(db));
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorBookCopies = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .ToArray()//sort in c sharp, no need to sort in database, just get the data
                .OrderByDescending(a => a.TotalBookCopies);

            return string.Join(Environment.NewLine,authorBookCopies.Select(a => $"{a.FirstName} {a.LastName} - {a.TotalBookCopies}"));
        }
    }
}
