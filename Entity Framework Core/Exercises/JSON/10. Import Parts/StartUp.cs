using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new();

        string jsonFileName = @"parts.json";

        string inputJson = File.ReadAllText(@$"../../../Datasets/{jsonFileName}");

        string importedMsg = ImportParts(context,inputJson);

        Console.WriteLine(importedMsg);
    }
    public static string ImportParts(CarDealerContext context,string inputJson)
    {
        Part[] parts = JsonConvert.DeserializeObject<Part[]>(inputJson)!;

        int[] suppliersIds = context.Suppliers
            .Select(s => s.Id)
            .ToArray();

        parts = parts
            .Where(p => suppliersIds.Contains(p.SupplierId))
            .ToArray();

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count()}.";
    }
}
