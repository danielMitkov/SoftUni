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

        string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");

        Console.WriteLine(ImportSuppliers(context,inputXml));
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
    public static string ImportSuppliers(CarDealerContext context,string inputXml)
    {
        SupplierDto[] supplierDtos = XmlDeserialize<SupplierDto[]>(inputXml,"Suppliers");

        Supplier[] suppliers = supplierDtos
            .Select(dto => new Supplier
            {
                IsImporter = dto.isImporter,
                Name = dto.name
            })
            .ToArray();

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {supplierDtos.Length}";
    }
}
