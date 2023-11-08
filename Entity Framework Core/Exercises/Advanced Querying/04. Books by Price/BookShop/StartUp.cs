namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByPrice(db));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksPrices = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                });
            return string.Join(Environment.NewLine,booksPrices.Select(obj => $"{obj.Title} - ${obj.Price:F2}"));
        }
    }
}
