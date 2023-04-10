using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string season = Console.ReadLine();
            double km = double.Parse(Console.ReadLine());
            double price = 0;
            switch (season) {
                case "Spring":
                case "Autumn":
                    if (km <= 5000) {
                        price = km * 0.75;
                    }else if (km <= 10000) {
                        price = km * 0.95;
                    } else if (km <= 20000) {
                        price = km * 1.45;
                    }
                    break;
                case "Summer":
                    if (km <= 5000) {
                        price = km * 0.9;
                    } else if (km <= 10000) {
                        price = km * 1.1;
                    } else if (km <= 20000) {
                        price = km * 1.45;
                    }
                    break;
                case "Winter":
                    if (km <= 5000) {
                        price = km * 1.05;
                    } else if (km <= 10000) {
                        price = km * 1.25;
                    } else if (km <= 20000) {
                        price = km * 1.45;
                    }
                    break;
            }
            price *= 4;
            price -= price * 0.1;
            Console.WriteLine($"{price:f2}");
        }
    }
}