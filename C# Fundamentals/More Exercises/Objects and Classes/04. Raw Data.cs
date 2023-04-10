using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var list = new List<Car>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var data = Console.ReadLine().Split();
            list.Add(new Car(data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), data[4]));
        }
        if (Console.ReadLine() == "fragile") {
            Console.Write(String.Join("\n", list.Where(x => x.Cargo.Type == "fragile" && x.Cargo.Weight < 1000)));
        } else {
            Console.Write(String.Join("\n", list.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)));
        }
    }
}
class Car {
    public Car(string model, int speed, int power, int weight, string type) {
        Model = model;
        Engine = new Engine(speed, power);
        Cargo = new Cargo(weight, type);
    }
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public override string ToString() {
        return Model;
    }
}
class Engine {
    public Engine(int speed, int power) {
        Speed = speed;
        Power = power;
    }
    public int Speed { get; set; }
    public int Power { get; set; }
}
class Cargo {
    public Cargo(int weight, string type) {
        Weight = weight;
        Type = type;
    }
    public int Weight { get; set; }
    public string Type { get; set; }
}