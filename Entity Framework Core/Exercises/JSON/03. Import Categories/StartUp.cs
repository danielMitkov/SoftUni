using ProductShop.Data;
using ProductShop.DTOs.Import;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string fileName = @"categories.json";

            string inputJson = File.ReadAllText(@$"../../../Datasets/{fileName}");

            Console.WriteLine(ImportCategories(context,inputJson));
        }
        public static string ImportCategories(ProductShopContext context,string inputJson)
        {
            List<ImportCategoryDto> categoriesDtos = JsonConvert.DeserializeObject<List<ImportCategoryDto>>(inputJson)!;

            Category[] categories = categoriesDtos
                .Where(dto => dto.Name != null)
                .Select(dto => new Category
                {
                    Name = dto.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
    }
}
