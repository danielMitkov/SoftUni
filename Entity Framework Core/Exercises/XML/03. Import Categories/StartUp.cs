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

        string xml = File.ReadAllText(@"../../../Datasets/categories.xml");

        Console.WriteLine(ImportCategories(shopContext,xml));
    }
    public static string ImportCategories(ProductShopContext context,string inputXml)
    {
        ImportCategoryDto[] categoryDtos = XmlDeserialize<ImportCategoryDto[]>(inputXml,"Categories");

        Category[] caterogies = categoryDtos
            .Select(dto => new Category
            {
                Name = dto.Name
            })
            .ToArray();

        context.Categories.AddRange(caterogies);
        context.SaveChanges();

        return $"Successfully imported {caterogies.Length}";
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
}
