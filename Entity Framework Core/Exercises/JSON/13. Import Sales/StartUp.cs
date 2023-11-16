using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string jsonFileName = @"sales.json";

        string inputJson = File.ReadAllText(@$"../../../Datasets/{jsonFileName}");

        string importedMsg = ImportSales(context,inputJson);

        Console.WriteLine(importedMsg);
    }
    public static string ImportSales(CarDealerContext context,string inputJson)
    {
        Sale[] sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)!;

        context.Sales.AddRange(sales);

        context.SaveChanges();

        return $"Successfully imported {sales.Count()}.";
    }
}
