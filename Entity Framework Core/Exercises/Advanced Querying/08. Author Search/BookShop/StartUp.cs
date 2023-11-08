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

            Console.WriteLine(GetAuthorNamesEndingIn(db,Console.ReadLine()));
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context,string input)
        {
            var authorNames = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a);

            return string.Join(Environment.NewLine,authorNames);
        }
    }
}
