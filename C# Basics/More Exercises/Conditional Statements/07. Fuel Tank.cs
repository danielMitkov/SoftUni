using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string type = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            switch (type) {
                case "Diesel":
                case "Gasoline":
                case "Gas":
                    if (liters >= 25) {
                        Console.WriteLine($"You have enough {type.ToLower()}.");
                    } else {
                        Console.WriteLine($"Fill your tank with {type.ToLower()}!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid fuel!");
                    break;
            }
        }
    }
}