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

        string jsonResult = GetSalesWithAppliedDiscount(context);

        Console.WriteLine(jsonResult);
    }
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .Take(10)
            .Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                discount = s.Discount,
                price = s.Car.PartsCars.Sum(pc => pc.Part.Price)
            })
            .AsNoTracking()
            .ToArray();

        var result = sales
            .Select(s => new
            {
                car = s.car,
                customerName = s.customerName,
                discount = s.discount.ToString("F2"),
                price = s.price.ToString("F2"),
                priceWithDiscount = (s.price - (s.price * (s.discount / 100))).ToString("F2")
            });

        return JsonConvert.SerializeObject(result,Formatting.Indented);
    }
}
