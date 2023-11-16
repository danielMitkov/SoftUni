using ProductShop.Data;
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

            Console.WriteLine(GetSoldProducts(context));
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                })
                .AsNoTracking()
                .ToArray()
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName);

            return JsonConvert.SerializeObject(users,Formatting.Indented);
        }
    }
}
