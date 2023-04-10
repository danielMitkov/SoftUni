using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            bool isWinter = Console.ReadLine() == "Winter" ? true : false;
            double price = 0;
            string destination = "";
            string sleep = "";
            if (budget <= 1000) {
                sleep = "Camp";
                if (isWinter) {
                    destination = "Morocco";
                    price = budget * 0.45;
                } else {
                    destination = "Alaska";
                    price = budget * 0.65;
                }
            } else if (budget <= 3000) {
                sleep = "Hut";
                if (isWinter) {
                    destination = "Morocco";
                    price = budget * 0.6;
                } else {
                    destination = "Alaska";
                    price = budget * 0.8;
                }
            } else if (budget > 3000) {
                sleep = "Hotel";
                if (isWinter) {
                    destination = "Morocco";
                    price = budget * 0.9;
                } else {
                    destination = "Alaska";
                    price = budget * 0.9;
                }
            }
            Console.WriteLine($"{destination} - {sleep} - {price:f2}");
        }
    }
}