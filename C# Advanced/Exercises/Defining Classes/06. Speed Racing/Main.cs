using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;
public class StartUp {
    public static void Main() {
        Dictionary<string,Car> cars = new();
        for(int n = int.Parse(Console.ReadLine());n > 0;n--) {
            string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            double fuel = double.Parse(data[1]);
            double fuelConsumKm = double.Parse(data[2]);
            cars.Add(model,new Car(fuel,fuelConsumKm));
        }
        string line = string.Empty;
        while((line = Console.ReadLine()) != "End") {
            string[] data = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string model = data[1];
            int km = int.Parse(data[2]);
            cars[model].Drive(km);
        }
        foreach(var (model, car) in cars) Console.WriteLine($"{model} {car.Fuel:F2} {car.Travelled}");
    }
}