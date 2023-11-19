using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");

        Console.WriteLine(ImportParts(context,inputXml));
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
    public static string ImportParts(CarDealerContext context,string inputXml)
    {
        PartDto[] partDtos = XmlDeserialize<PartDto[]>(inputXml,"Parts");

        int[] supplierIds = context.Suppliers
            .Select(s => s.Id)
            .ToArray();

        Part[] parts = partDtos
            .Where(dto => supplierIds.Contains(dto.supplierId))
            .Select(dto => new Part
            {
                Name = dto.name,
                Quantity = dto.quantity,
                Price = dto.price,
                SupplierId = dto.supplierId
            })
            .ToArray();

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Length}";
    }
}
