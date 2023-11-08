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

            Console.WriteLine(GetBooksByCategory(db,Console.ReadLine()));
        }
        public static string GetBooksByCategory(BookShopContext context,string input)
        {
            string[] categories = input.ToLower().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            var titles = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .OrderBy(bc => bc.Book.Title)
                .Select(bc => bc.Book.Title);

            return string.Join(Environment.NewLine,titles);
        }
    }
}
