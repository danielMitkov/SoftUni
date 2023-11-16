using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string jsonFileName = @"cars.json";

        string inputJson = File.ReadAllText(@$"../../../Datasets/{jsonFileName}");

        string importedMsg = ImportCars(context,inputJson);

        Console.WriteLine(importedMsg);
    }
    public static string ImportCars(CarDealerContext context,string inputJson)
    {
        ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson)!;

        // First way - add the parts to the cars

        //Car[] cars = carDtos
        //    .Select(dto => new Car
        //    {
        //        Make = dto.Make,
        //        Model = dto.Model,
        //        TraveledDistance = dto.TraveledDistance
        //    })
        //    .ToArray();

        //foreach(var dto in carDtos)
        //{
        //    dto.PartsId = dto.PartsId.Distinct().ToList();
        //}

        //for(int iCar = 0;iCar < cars.Length;iCar++)
        //{
        //    for(int iPart = 0;iPart < carDtos[iCar].PartsId.Count;iPart++)
        //    {
        //        cars[iCar].PartsCars.Add(new PartCar
        //        {
        //            Car = cars[iCar],
        //            PartId = carDtos[iCar].PartsId[iPart]
        //        });
        //    }
        //}

        //context.Cars.AddRange(cars);

        // Second way - add the parts to their table

        Car[] cars = carDtos
            .Select(dto => new Car
            {
                Make = dto.Make,
                Model = dto.Model,
                TraveledDistance = dto.TraveledDistance
            })
            .ToArray();

        context.Cars.AddRange(cars);

        List<PartCar> parts = new();

        for(int iCar = 0; iCar < cars.Length; ++iCar)
        {
            foreach(int partId in carDtos[iCar].PartsId.Distinct())
            {
                parts.Add(new PartCar
                {
                    PartId = partId,
                    Car = cars[iCar]
                });
            }
        }

        context.PartsCars.AddRange(parts);

        context.SaveChanges();

        return $"Successfully imported {cars.Count()}.";
    }
}
