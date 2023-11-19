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

        string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");

        Console.WriteLine(ImportCustomers(context,inputXml));
    }
    public static T XmlDeserialize<T>(string xml,string rootName)
    {
        XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

        using StringReader reader = new(xml);

        return (T)serializer.Deserialize(reader)!;
    }
    public static string ImportCars(CarDealerContext context,string inputXml)
    {
        CarDto[] carDtos = XmlDeserialize<CarDto[]>(inputXml,"Cars");

        int[] partIds = context.Parts
            .Select(s => s.Id)
            .ToArray();

        Car[] cars = new Car[carDtos.Length];

        for(int i = 0;i < cars.Length;++i)
        {
            cars[i] = new Car
            {
                Make = carDtos[i].make,
                Model = carDtos[i].model,
                TraveledDistance = carDtos[i].traveledDistance,
                PartsCars = carDtos[i].parts
                    .DistinctBy(dto => dto.PartId)
                    .Where(dto => partIds.Contains(dto.PartId))
                    .Select(dto => new PartCar
                    {
                        PartId = dto.PartId,
                        Car = cars[i]
                    })
                    .ToList()
            };
        }

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Length}";
    }
    public static string ImportCustomers(CarDealerContext context,string inputXml)
    {
        CustomerDto[] customerDtos = XmlDeserialize<CustomerDto[]>(inputXml,"Customers");

        Customer[] customers = customerDtos
            .Select(dto => new Customer
            {
                Name = dto.name,
                BirthDate = dto.birthDate,
                IsYoungDriver = dto.isYoungDriver
            })
            .ToArray();

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}";
    }
}
