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

        string jsonResult = GetOrderedCustomers(context);

        Console.WriteLine(jsonResult);
    }
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)// false comes first
            .Select(c => new
            {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                IsYoungDriver = c.IsYoungDriver
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }
}
