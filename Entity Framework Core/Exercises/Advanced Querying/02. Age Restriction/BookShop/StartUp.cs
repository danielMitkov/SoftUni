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

            Console.WriteLine(GetBooksByAgeRestriction(db,Console.ReadLine()));
        }
        public static string GetBooksByAgeRestriction(BookShopContext context,string command)
        {
            AgeRestriction enumValue = Enum.Parse<AgeRestriction>(command,true);

            string[] books = context.Books
                .Where(b => b.AgeRestriction == enumValue)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine,books);
        }
    }
}
