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

        string xml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

        Console.WriteLine(ImportCategoryProducts(shopContext,xml));
    }
    public static string ImportCategoryProducts(ProductShopContext context,string inputXml)
    {
        ImportCategoryProductDto[] categoryProductDtos = XmlDeserialize<ImportCategoryProductDto[]>(inputXml,"CategoryProducts");

        int[] categoryIds = context.Categories
            .Select(c => c.Id)
            .ToArray();

        int[] productIds = context.Products
            .Select(p => p.Id)
            .ToArray();

        CategoryProduct[] categoryProducts = categoryProductDtos
            .Where(dto => categoryIds.Contains(dto.CategoryId) && productIds.Contains(dto.ProductId))//just in case
            .Select(dto => new CategoryProduct
            {
                CategoryId = dto.CategoryId,
                ProductId = dto.ProductId
            })
            .ToArray();

        context.CategoryProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
}
