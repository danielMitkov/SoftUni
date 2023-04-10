using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double budget = double.Parse(Console.ReadLine());
            double nights = double.Parse(Console.ReadLine());
            double cost = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            if (nights > 7) {
                cost -= cost * 0.05;
            }
            double totalCost = cost * nights;
            double totalOther = budget * (percent / 100.0);
            totalCost += totalOther;
            if (totalCost <= budget) {
                Console.WriteLine($"Ivanovi will be left with {budget - totalCost:f2} leva after vacation.");
            } else {
                Console.WriteLine($"{totalCost - budget:f2} leva needed.");
            }

        }
    }
}