using ProductShop.Data;
using ProductShop.DTOs.Export;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext shopContext = new();

        Console.WriteLine(GetUsersWithProducts(shopContext));
    }
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        ExportUserDto[] userDtos = context.Users
            .Where(u => u.ProductsSold.Any())
            .OrderByDescending(u => u.ProductsSold.Count)
            .Take(10)
            .Select(u => new ExportUserDto
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                age = u.Age,
                SoldProducts = new ExportSoldProductsDto
                {
                    products = u.ProductsSold
                        .OrderByDescending(ps => ps.Price)
                        .Select(ps => new ExportProductDto
                        {
                            name = ps.Name,
                            price = ps.Price
                        })
                        .ToArray()
                }
            })
            .ToArray();

        int validUsersCount = context.Users
            .Where(u => u.ProductsSold.Any())
            .Count();// weird, you need to display the count of all users but show only 10 users

        ExportUsersDto usersDto = new ExportUsersDto
        {
            count = validUsersCount,
            users = userDtos
        };// there are only 10 users in users collection but count must show all users before .Take(10)

        return XmlSerialize(usersDto,"Users");
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
