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

        Console.WriteLine(GetCategoriesByProductsCount(context));
    }
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoriesProducts.Count,
                averagePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                totalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("f2")
            })
            .OrderByDescending(c => c.productsCount)
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(categories,Formatting.Indented);
    }
}
