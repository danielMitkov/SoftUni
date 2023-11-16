using CarDealer.Data;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string jsonResult = GetCarsWithTheirListOfParts(context);

        Console.WriteLine(jsonResult);//cant fit in the console, get by debug or write to file
    }
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsParts = context.Cars
            .Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                },
                parts = c.PartsCars
                    .Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    })
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(carsParts, Formatting.Indented);
    }
}
