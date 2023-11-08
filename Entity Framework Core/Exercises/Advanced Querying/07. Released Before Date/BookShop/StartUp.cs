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

            Console.WriteLine(GetBooksReleasedBefore(db,Console.ReadLine()));
        }
        public static string GetBooksReleasedBefore(BookShopContext context,string dateStr)
        {
            DateTime date = DateTime.ParseExact(dateStr,"dd-MM-yyyy",CultureInfo.InvariantCulture);

            var booksInfo = context.Books
                .Where(b => b.ReleaseDate < date)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                });
            return string.Join(Environment.NewLine,booksInfo.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));
        }
    }
}
