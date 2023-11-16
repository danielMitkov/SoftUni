using ProductShop.Data;
using ProductShop.DTOs.Export;
using Newtonsoft.Json;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            Console.WriteLine(GetProductsInRange(context));
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .AsNoTracking()
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerFirstName = p.Seller.FirstName,
                    SellerLastName = p.Seller.LastName
                })
                .ToArray()//get the data and sort in c sharp
                .OrderBy(dto => dto.Price);

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}
