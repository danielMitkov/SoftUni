using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        Console.WriteLine(GetCarsWithTheirListOfParts(context));
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
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        CarDto[] carDtos = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .Select(c => new CarDto
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars
                    .OrderByDescending(pc => pc.Part.Price)
                    .Select(pc => new PartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .ToArray()
            })
            .ToArray();

        return XmlSerialize(carDtos,"cars");
    }
}
