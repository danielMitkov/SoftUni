using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        Console.WriteLine(GetTotalSalesByCustomer(context));
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
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        CustomerDto[] customerDtos = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new CustomerDto
            {
                FullName = c.Name,
                BoughtCarsCount = c.Sales.Count,
                SpentMoney = c.Sales
                    .SelectMany(s => s.Car.PartsCars.Select(pc => Math.Round(c.IsYoungDriver ? pc.Part.Price * 0.95m : pc.Part.Price,2)))
                    .Sum()
            })
            .OrderByDescending(dto => dto.SpentMoney)
            .ToArray();

        return XmlSerialize(customerDtos,"customers");
    }
}
