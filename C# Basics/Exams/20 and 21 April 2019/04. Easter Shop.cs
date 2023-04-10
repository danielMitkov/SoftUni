using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double eggs = double.Parse(Console.ReadLine());
            double sold = 0;
            while (true) {
                string text = Console.ReadLine();
                if (text == "Close") {
                    Console.WriteLine("Store is closed!");
                    Console.WriteLine($"{sold} eggs sold.");
                    return;
                }
                double amount = double.Parse(Console.ReadLine());
                if (text == "Buy") {
                    if (amount > eggs) {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggs}.");
                        return;
                    }
                    eggs -= amount;
                    sold += amount;
                }
                if (text == "Fill") {
                    eggs += amount;
                }
            }
        }
    }
}