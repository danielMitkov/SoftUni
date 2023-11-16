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

        string jsonResult = GetTotalSalesByCustomer(context);

        Console.WriteLine(jsonResult);
    }
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var carsParts = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                fullName = c.Name,
                boughtCars = c.Sales.Count,
                spentMoney = c.Sales
                    .SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price))
                    .Sum()
            })
            .AsNoTracking()
            .ToArray()
            .OrderByDescending(c => c.spentMoney)
            .ThenByDescending(c => c.boughtCars);

        return JsonConvert.SerializeObject(carsParts,Formatting.Indented);
    }
}
