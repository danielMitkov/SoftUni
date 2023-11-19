using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        Console.WriteLine(GetCarsFromMakeBmw(context));
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
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        CarDto[] carDtos = context.Cars
            .Where(c => c.Make == "BMW")
            .Select(c => new CarDto
            {
                id = c.Id,
                model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .ToArray()
            .OrderBy(dto => dto.model)
            .ThenByDescending(dto => dto.TraveledDistance)
            .ToArray();

        return XmlSerialize(carDtos,"cars");
    }
}
