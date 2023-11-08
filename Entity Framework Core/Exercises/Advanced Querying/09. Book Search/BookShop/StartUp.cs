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

            Console.WriteLine(GetBookTitlesContaining(db,Console.ReadLine()));
        }
        public static string GetBookTitlesContaining(BookShopContext context,string input)
        {
            var titles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            return string.Join(Environment.NewLine,titles);
        }
    }
}
