using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            double cards = double.Parse(Console.ReadLine()) * 250;
            double procesors = double.Parse(Console.ReadLine()) * (cards * 0.35);
            double rams = double.Parse(Console.ReadLine()) * (cards * 0.1);

            double price = cards + procesors + rams;

            if ((cards / 250) > (procesors / (cards * 0.35))) {

                price *= 0.85;
            }
            if (budget >= price) {

                Console.WriteLine($"You have {(budget - price):F2} leva left!");
            }else {
                Console.WriteLine($"Not enough money! You need {(price - budget):F2} leva more!");
            }
        }
    }
}