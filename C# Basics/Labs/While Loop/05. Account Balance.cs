using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            double sum = 0;
            while (input != "NoMoreMoney") {
                if (double.Parse(input) < 0) {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {double.Parse(input):F2}");
                sum += double.Parse(input);
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}