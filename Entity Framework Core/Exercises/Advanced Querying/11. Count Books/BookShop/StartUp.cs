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

            Console.WriteLine(CountBooks(db,int.Parse(Console.ReadLine())));
        }
        public static int CountBooks(BookShopContext context,int lengthCheck)
        {
            var count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }
    }
}
