using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var catalog = new Catalog();
        while (true) {
            string line = Console.ReadLine();
            if (line == "end") break;
            var data = line.Split('/');
            if (data[0] == "Car") catalog.Cars.Add(new Car() { Logo = data[1], Type = data[2], Hp = data[3] });
            else catalog.Trucks.Add(new Truck() { Logo = data[1], Type = data[2], Kg = data[3] });
        }
        if (catalog.Cars.Count > 0) {
            Console.WriteLine("Cars:");
            catalog.Cars.OrderBy(x => x.Logo).ToList().ForEach(x => Console.WriteLine($"{x.Logo}: {x.Type} - {x.Hp}hp"));
        }
        if (catalog.Trucks.Count > 0) {
            Console.WriteLine("Trucks:");
            catalog.Trucks.OrderBy(x => x.Logo).ToList().ForEach(x => Console.WriteLine($"{x.Logo}: {x.Type} - {x.Kg}kg"));
        }
    }
}
class Truck {
    public string Logo { get; set; }
    public string Type { get; set; }
    public string Kg { get; set; }
}
class Car {
    public string Logo { get; set; }
    public string Type { get; set; }
    public string Hp { get; set; }
}
class Catalog {
    public List<Truck> Trucks { get; set; } = new List<Truck>();
    public List<Car> Cars { get; set; } = new List<Car>();
}