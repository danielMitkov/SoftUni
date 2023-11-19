using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext shopContext = new();

        string xml = File.ReadAllText(@"../../../Datasets/users.xml");

        Console.WriteLine(ImportUsers(shopContext,xml));
    }
    public static string ImportUsers(ProductShopContext context,string inputXml)
    {
        ImportUserDto[] userDtos = XmlDeserialize<ImportUserDto[]>(inputXml,"Users");

        User[] users = userDtos
            .Select(dto => new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age
            })
            .ToArray();

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Length}";
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
}
