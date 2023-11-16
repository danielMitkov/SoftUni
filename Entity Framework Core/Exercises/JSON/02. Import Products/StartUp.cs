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

            string fileName = @"products.json";

            string inputJson = File.ReadAllText(@$"../../../Datasets/{fileName}");

            Console.WriteLine(ImportProducts(context,inputJson));
        }
        public static string ImportProducts(ProductShopContext context,string inputJson)
        {
            var productDtos = JsonConvert.DeserializeObject<ICollection<ImportProductDto>>(inputJson);

            var products = productDtos!.Select(dto => new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                SellerId = dto.SellerId,
                BuyerId = dto.BuyerId
            });

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
    }
}
