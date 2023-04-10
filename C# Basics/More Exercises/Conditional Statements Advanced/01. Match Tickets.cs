using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            bool wantVip = Console.ReadLine() == "VIP" ? true : false;
            double people = double.Parse(Console.ReadLine());
            double transport = 0;
            if (people >= 1 && people <= 4) {
                transport = 0.75;
            }else if (people >= 5 && people <= 9) {
                transport = 0.6;
            }else if(people >= 10 && people <= 24) {
                transport = 0.5;
            }else if (people >= 25 && people <= 49) {
                transport = 0.4;
            } else if (people >= 50) {
                transport = 0.25;
            }
            budget -= budget * transport;
            if (wantVip) {
                if (budget >= 499.99 * people) {
                Console.WriteLine($"Yes! You have {(budget - 499.99 * people):f2} leva left.");
                } else {
                    Console.WriteLine($"Not enough money! You need {(499.99 * people - budget):f2} leva.");
                }
            }
            if (!wantVip) {
                if (budget >= 249.99 * people) {
                    Console.WriteLine($"Yes! You have {(budget - 249.99 * people):f2} leva left.");
                } else {
                    Console.WriteLine($"Not enough money! You need {(249.99 * people - budget):f2} leva.");
                }
            }
        }
    }
}