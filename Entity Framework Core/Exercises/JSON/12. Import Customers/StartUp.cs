using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string jsonFileName = @"customers.json";

        string inputJson = File.ReadAllText(@$"../../../Datasets/{jsonFileName}");

        string importedMsg = ImportCustomers(context,inputJson);

        Console.WriteLine(importedMsg);
    }
    public static string ImportCustomers(CarDealerContext context,string inputJson)
    {
        Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(inputJson)!;

        context.Customers.AddRange(customers);

        context.SaveChanges();

        return $"Successfully imported {customers.Count()}.";
    }
}
