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

        string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");

        Console.WriteLine(ImportSales(context,inputXml));
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
    public static string ImportSales(CarDealerContext context,string inputXml)
    {
        SaleDto[] saleDtos = XmlDeserialize<SaleDto[]>(inputXml,"Sales");

        int[] carIds = context.Cars
            .Select(c => c.Id)
            .ToArray();

        Sale[] sales = saleDtos
            .Where(dto => carIds.Contains(dto.carId))
            .Select(dto => new Sale
            {
                CarId = dto.carId,
                CustomerId = dto.customerId,
                Discount = dto.discount
            })
            .ToArray();

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Length}";
    }
}
