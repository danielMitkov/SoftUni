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

        string xml = File.ReadAllText(@"../../../Datasets/products.xml");

        Console.WriteLine(ImportProducts(shopContext,xml));
    }
    public static string ImportProducts(ProductShopContext context,string inputXml)
    {
        ImportProductDto[] productDtos = XmlDeserialize<ImportProductDto[]>(inputXml,"Products");

        Product[] products = productDtos
            .Select(dto => new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                SellerId = dto.SellerId,
                BuyerId = dto.BuyerId
            })
            .ToArray();

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
}
