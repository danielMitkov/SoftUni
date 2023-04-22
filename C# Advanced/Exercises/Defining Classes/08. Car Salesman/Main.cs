using System;
using System.Collections.Generic;
using System.Linq;
namespace DefiningClasses;
public class StartUp
{
    public static void Main()
    {
        List<Engine> engines = new();
        for(int n = int.Parse(Console.ReadLine());n > 0;n--)
        {
            var data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            string model = data[0];
            data.RemoveAt(0);
            int power = int.Parse(data[0]);
            data.RemoveAt(0);
            int displacement = 0;
            if(data.Count >= 1 && int.TryParse(data[0],out displacement))
            {
                data.RemoveAt(0);
            }
            string efficiency = "n/a";
            if(data.Count >= 1 && !int.TryParse(data[0],out _))
            {
                efficiency = data[0];
                data.RemoveAt(0);
            }
            if(data.Count == 1 && int.TryParse(data[0],out displacement))
            {
                data.RemoveAt(0);
            }
            engines.Add(new Engine(model,power,displacement,efficiency));
        }
        List<Car> cars = new();
        for(int n = int.Parse(Console.ReadLine());n > 0;n--)
        {
            var data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            string model = data[0];
            data.RemoveAt(0);
            Engine engine = engines.Find(x=>x.Model == data[0]);
            data.RemoveAt(0);
            int weight = 0;
            if(data.Count >= 1 && int.TryParse(data[0],out weight))
            {
                data.RemoveAt(0);
            }
            string color = "n/a";
            if(data.Count >= 1 && !int.TryParse(data[0],out _))
            {
                color = data[0];
                data.RemoveAt(0);
            }
            if(data.Count == 1 && int.TryParse(data[0],out weight))
            {
                data.RemoveAt(0);
            }
            cars.Add(new Car(model,engine,weight,color));
        }
        foreach(var car in cars)
        {
            Console.Write(car);
        }
    }
}