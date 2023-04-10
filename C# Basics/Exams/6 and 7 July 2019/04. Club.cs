using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double target = double.Parse(Console.ReadLine());
            string drink = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            double income = 0;
            while (drink != "Party!") {
                double price = drink.Length;
                price *= count;
                if(price % 2 != 0) {
                    price -= price * 0.25;
                }
                income += price;
                if (income >= target) {
                    Console.WriteLine("Target acquired.");
                    Console.WriteLine($"Club income - {income:f2} leva.");
                    return;
                }
                drink = Console.ReadLine();
                if (drink == "Party!") {
                    break;
                }
                count = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"We need {target - income:f2} leva more.");
            Console.WriteLine($"Club income - {income:f2} leva.");
        }
    }
}