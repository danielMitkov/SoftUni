using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        Console.WriteLine(GetCarsWithDistance(context));
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
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        CarDto[] carDtos = context.Cars
            .Where(c => c.TraveledDistance > 2_000_000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .Select(c => new CarDto
            {
                make = c.Make,
                model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .ToArray();

        return XmlSerialize(carDtos,"cars");
    }
}
