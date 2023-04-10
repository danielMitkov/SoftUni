using System;
class Program {
    static void Main(string[] args) {
        string product = Console.ReadLine();
        int amount = int.Parse(Console.ReadLine());
        PrintPrice(product, amount);
    }
    static void PrintPrice(string product, int amount) {
        if (product == "coffee") {
            Console.WriteLine($"{amount * 1.5:f2}");
        }
        if (product == "water") {
            Console.WriteLine($"{amount * 1:f2}");
        }
        if (product == "coke") {
            Console.WriteLine($"{amount * 1.4:f2}");
        }
        if (product == "snacks") {
            Console.WriteLine($"{amount * 2:f2}");
        }
    }
}