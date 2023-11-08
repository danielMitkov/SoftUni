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

            IncreasePrices(db);
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var oldBooks = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach(var book in oldBooks)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
    }
}
