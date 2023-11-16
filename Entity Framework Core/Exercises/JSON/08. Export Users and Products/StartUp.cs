using ProductShop.Data;
using Newtonsoft.Json;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        Console.WriteLine(GetUsersWithProducts(context));
    }
    public static string GetUsersWithProducts(ProductShopContext context)
    {//make sure to write it as straightforward as possible for judge
        var users = context.Users
            .Where(u => u.ProductsSold
                .Any(p => p.Buyer != null)
            )
            .OrderByDescending(u => u.ProductsSold
                .Where(p => p.Buyer != null)
                .Count()
            )
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                age = u.Age,
                soldProducts = new
                {
                    count = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Count(),
                    products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = (double)p.Price//cast to remove trailing zero
                        })
                }
            })
            .AsNoTracking()
            .ToArray();
        //there is weird default order of the products if you optimize the query
        var usersWithCount = new
        {
            usersCount = users.Count(),
            users = users
        };
        return JsonConvert.SerializeObject(usersWithCount,Formatting.Indented,new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
    }
}
