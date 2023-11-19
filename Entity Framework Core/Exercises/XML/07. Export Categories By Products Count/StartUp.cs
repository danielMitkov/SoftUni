using ProductShop.Data;
using ProductShop.DTOs.Export;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext shopContext = new();

        Console.WriteLine(GetCategoriesByProductsCount(shopContext));
    }
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        ExportCategoryDto[] categories = context.Categories
            .Select(c => new ExportCategoryDto
            {
                name = c.Name,
                count = c.CategoryProducts.Count,
                averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
            })
            .ToArray()
            .OrderByDescending(c => c.count)
            .ThenBy(c => c.totalRevenue)
            .ToArray();

        return XmlSerialize(categories,"Categories");
    }
    public static string XmlSerialize<T>(T obj,string rootName) where T : class
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringWriter writer = new();

        XmlSerializerNamespaces namespaces = new();
        namespaces.Add(string.Empty,string.Empty);

        serializer.Serialize(writer,obj,namespaces);

        return writer.ToString();
    }
}
