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

            Console.WriteLine(GetTotalProfitByCategory(db));
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryProfits = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(bc => bc.Book.Price * bc.Book.Copies)
                })
                .ToArray()
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name);

            return string.Join(Environment.NewLine,categoryProfits.Select(c => $"{c.Name} ${c.TotalProfit:F2}"));
        }
    }
}
