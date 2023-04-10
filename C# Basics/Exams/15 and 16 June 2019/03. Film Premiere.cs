using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string m = Console.ReadLine();
            string p = Console.ReadLine();
            double c = double.Parse(Console.ReadLine());
            double price = 0;
            switch (m) {
                case "Star Wars":
                    price = GetPrice(p, 18, 25, 30);
                    price *= c;
                    if (c >= 4) {
                        price -= price * 0.30;
                    }
                    break;
                case "Jumanji":
                    price = GetPrice(p, 9, 11, 14);
                    price *= c;
                    if (c == 2) {
                        price -= price * 0.15;
                    }
                    break;
                case "John Wick":
                    price = GetPrice(p, 12, 15, 19);
                    price *= c;
                    break;
            }
            Console.WriteLine($"Your bill is {price:f2} leva.");
        }
        static double GetPrice(string p, double a, double b, double c) {
            if (p == "Drink") {
                return a;
            }
            if (p == "Popcorn") {
                return b;
            }
            if (p == "Menu") {
                return c;
            }
            return 0;
        }
    }
}