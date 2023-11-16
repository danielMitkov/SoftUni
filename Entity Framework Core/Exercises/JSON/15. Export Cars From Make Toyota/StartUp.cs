using CarDealer.Data;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string jsonResult = GetCarsFromMakeToyota(context);

        Console.WriteLine(jsonResult);
    }
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var cars = context.Cars
            .Where(c => c.Make == "Toyota")
            .Select(c => new
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .AsNoTracking()
            .ToArray()
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance);

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }
}
