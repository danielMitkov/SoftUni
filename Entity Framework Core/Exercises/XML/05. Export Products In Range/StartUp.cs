using ProductShop.Data;
using ProductShop.DTOs.Export;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext shopContext = new();

        Console.WriteLine(GetProductsInRange(shopContext));
    }
    public static string GetProductsInRange(ProductShopContext context)
    {
        ExportProductDto[] productDtos = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .Select(p => new ExportProductDto
            {
                Name = p.Name,
                Price = p.Price,
                Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
            })
            .ToArray();

        return XmlSerialize(productDtos,"Products");
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
