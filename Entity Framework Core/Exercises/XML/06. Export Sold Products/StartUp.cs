using ProductShop.Data;
using ProductShop.DTOs.Export;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext shopContext = new();

        Console.WriteLine(GetSoldProducts(shopContext));
    }
    public static string GetSoldProducts(ProductShopContext context)
    {
        ExportUserDto[] userDtos = context.Users
            .Where(u => u.ProductsSold.Count >= 1)
            .OrderBy(u => u.LastName)
            .ThenBy(u=>u.FirstName)
            .Take(5)
            .Select(u => new ExportUserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.ProductsSold
                    .Select(ps => new ExportProductDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
            })
            .ToArray();

        return XmlSerialize(userDtos,"Users");
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
