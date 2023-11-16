using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");

        Console.WriteLine(ImportSuppliers(context,inputJson));
    }
    public static string ImportSuppliers(CarDealerContext context,string inputJson)
    {
        Supplier[] suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson)!;

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count()}.";
    }
}
