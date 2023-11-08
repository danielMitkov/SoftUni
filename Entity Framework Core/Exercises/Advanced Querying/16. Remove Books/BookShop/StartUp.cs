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

            Console.WriteLine(RemoveBooks(db));
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var unpopularBooks = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            context.RemoveRange(unpopularBooks);

            context.SaveChanges();

            return unpopularBooks.Count();
        }
    }
}
