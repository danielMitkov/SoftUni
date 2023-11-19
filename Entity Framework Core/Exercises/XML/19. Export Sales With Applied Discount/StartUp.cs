using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        Console.WriteLine(GetSalesWithAppliedDiscount(context));
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
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        SaleDto[] saleDtos = context.Sales
            .Select(s => new SaleDto
            {
                Car = new CarDto
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                Discount = s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                PriceWithDiscount = (double)(s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100)))
            })
            .ToArray();// cast to double just to remove trailing zeros

        return XmlSerialize(saleDtos,"sales");
    }
}
