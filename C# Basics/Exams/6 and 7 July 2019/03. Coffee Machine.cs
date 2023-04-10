using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double price = 0;
            switch (drink) {
                case "Espresso":
                    price = GetPrice(sugar, 0.9, 1, 1.2);
                    price = price * count;
                    if (sugar == "Without") {
                        price -= price * 0.35;
                    }
                    if (count >= 5) {
                        price -= price * 0.25;
                    }
                    break;
                case "Cappuccino":
                    price = GetPrice(sugar, 1, 1.2, 1.6);
                    price = price * count;
                    if (sugar == "Without") {
                        price -= price * 0.35;
                    }
                    break;
                case "Tea":
                    price = GetPrice(sugar, 0.5, 0.6, 0.7);
                    price = price * count;
                    if (sugar == "Without") {
                        price -= price * 0.35;
                    }
                    break;
            }
            if (price > 15) {
                price -= price * 0.2;
            }
            Console.WriteLine($"You bought {count} cups of {drink} for {price:f2} lv.");
        }
        static double GetPrice(string choice, double without, double normal, double extra) {
            switch (choice) {
                case "Without":
                    return without;
                case "Normal":
                    return normal;
                case "Extra":
                    return extra;
            }
            return 0;
        }
    }
}