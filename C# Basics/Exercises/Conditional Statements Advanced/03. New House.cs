using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string type = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double sum = 0;
            switch (type) {
                case "Roses":
                    sum = calc(80, 10, 5.0, count);
                    break;
                case "Dahlias":
                    sum = calc(90, 15, 3.8, count);
                    break;
                case "Tulips":
                    sum = calc(80, 15, 2.8, count);
                    break;
                case "Narcissus":
                    sum = calc(120, -15, 3.0, count);
                    break;
                case "Gladiolus":
                    sum = calc(80, -20, 2.5, count);
                    break;
            }
            if (budget >= sum) {
                Console.WriteLine($"Hey, you have a great garden with {count} {type} and {(budget - sum):F2} leva left.");
            } else {
                Console.WriteLine($"Not enough money, you need {(sum - budget):F2} leva more.");
            }
        }
        static double calc(int threshold, int percent, double price, int count) {
            bool doPercent = false;
            if (percent > 0) {
                if (count > threshold) {
                    doPercent = true;
                }
            } else {
                if (count < threshold) {
                    doPercent = true;
                }
            }
            double clean = price * count;
            if (doPercent) { 
                return clean - (clean * (percent / 100.0));
            }
            return clean;
        }
    }
}