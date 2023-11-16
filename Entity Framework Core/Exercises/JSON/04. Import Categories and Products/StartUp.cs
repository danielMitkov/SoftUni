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

            string fileName = @"categories-products.json";

            string inputJson = File.ReadAllText(@$"../../../Datasets/{fileName}");

            Console.WriteLine(ImportCategoryProducts(context,inputJson));
        }
        public static string ImportCategoryProducts(ProductShopContext context,string inputJson)
        {
            List<ImportCategoryProductDto> categoriesProductsDtos = JsonConvert.DeserializeObject<List<ImportCategoryProductDto>>(inputJson)!;

            CategoryProduct[] categoriesProducts = categoriesProductsDtos
                .Select(dto => new CategoryProduct
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                })
                .ToArray();

            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }
    }
}
