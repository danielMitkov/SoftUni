using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
        double budget = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        int count = int.Parse(Console.ReadLine());
            double left = 0;
            switch (season) {
                case "Spring":
                    left = budget - getPrice(3000, true, count);
                    break;
                case "Summer":
                    left = budget - getPrice(4200, true, count);
                    break;
                case "Autumn":
                    left = budget - getPrice(4200, false, count);
                    break;
                case "Winter":
                    left = budget - getPrice(2600, true, count);
                    break;
            }
            if (left >= 0) { 
                Console.WriteLine($"Yes! You have {left:F2} leva left.");
            } else {
                Console.WriteLine($"Not enough money! You need {Math.Abs(left):F2} leva.");
            }
        }
        static double getPrice(double price, bool doEvenCheck, int count) {
            if (count <= 6) {
                price -= price * 0.1;
            } else if (count >= 7 && count <= 11) {
                price -= price * 0.15;
            } else if (count >= 12) {
                price -= price * 0.25;
            }
            if (count % 2 == 0 && doEvenCheck) {
                price -= price * 0.05;
            }
            return price;
        }
    }
}