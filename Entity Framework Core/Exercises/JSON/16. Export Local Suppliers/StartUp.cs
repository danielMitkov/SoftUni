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

        string jsonResult = GetLocalSuppliers(context);

        Console.WriteLine(jsonResult);
    }
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount  = s.Parts.Count
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
    }
}
