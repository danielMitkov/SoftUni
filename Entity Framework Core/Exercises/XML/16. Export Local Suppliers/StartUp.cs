using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        Console.WriteLine(GetLocalSuppliers(context));
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
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        SupplierDto[] supplierDtos = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new SupplierDto
            {
                id = s.Id,
                name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return XmlSerialize(supplierDtos,"suppliers");
    }
}
