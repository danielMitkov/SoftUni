using System;
using System.Collections.Generic;
using System.Linq;
namespace DefiningClasses;
public class StartUp
{
    public static void Main()
    {
        List<Car> cars = new();
        for(int n = int.Parse(Console.ReadLine());n > 0;n--)
        {
            string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            int engineSpeed = int.Parse(data[1]);
            int enginePower = int.Parse(data[2]);
            int cargoWeight = int.Parse(data[3]);
            string cargoType = data[4];
            double tire1Pressure = double.Parse(data[5]);
            int tire1Age = int.Parse(data[6]);
            double tire2Pressure = double.Parse(data[7]);
            int tire2Age = int.Parse(data[8]);
            double tire3Pressure = double.Parse(data[9]);
            int tire3Age = int.Parse(data[10]);
            double tire4Pressure = double.Parse(data[11]);
            int tire4Age = int.Parse(data[12]);
            Engine engine = new(engineSpeed,enginePower);
            Cargo cargo = new Cargo(cargoType,cargoWeight);
            Tire[] tires = new Tire[4] {
                new Tire(tire1Pressure,tire1Age),
                new Tire(tire2Pressure,tire2Age),
                new Tire(tire3Pressure,tire3Age),
                new Tire(tire4Pressure,tire4Age)
            };
            cars.Add(new Car(model,engine,cargo,tires));
        }
        if(Console.ReadLine() == "fragile")
        {
            foreach(var car in cars
                .Where(x => x.Cargo.Type == "fragile")
                .Where(x => x.Tires
                .Any(x => x.Pressure < 1)))
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            foreach(var car in cars
                .Where(x => x.Cargo.Type == "flammable")
                .Where(x => x.Engine.Power > 250))
            {
                Console.WriteLine(car);
            }
        }
    }
}