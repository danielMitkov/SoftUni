using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            bool isWinter = Console.ReadLine() == "Winter" ? true : false;
            double price = 0;
            string type = "";
            string klas = "";
            if (budget <= 100) {
                klas = "Economy class";
                if (isWinter) {
                    type = "Jeep";
                    price = budget * 0.65;
                } else {
                    type = "Cabrio";
                    price = budget * 0.35;
                }
            } else if (budget <= 500) {
                klas = "Compact class";
                if (isWinter) {
                    type = "Jeep";
                    price = budget * 0.8;
                } else {
                    type = "Cabrio";
                    price = budget * 0.45;
                }
            } else if (budget > 500) {
                klas = "Luxury class";
                type = "Jeep";
                price = budget * 0.9;
            }
            Console.WriteLine($"{klas}");
            Console.WriteLine($"{type} - {price:f2}");
        }
    }
}