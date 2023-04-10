using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double p1 = double.Parse(Console.ReadLine());
            double p2 = double.Parse(Console.ReadLine());
            while (true) {
                string text = Console.ReadLine();
                if (text == "End") {
                    Console.WriteLine($"Player one has {p1} eggs left.");
                    Console.WriteLine($"Player two has {p2} eggs left.");
                    return;
                }
                if (text == "one") {
                    p2--;
                    if (p2 == 0) {
                        Console.WriteLine($"Player two is out of eggs. Player one has {p1} eggs left.");
                        return;
                    }
                }
                if (text == "two") {
                    p1--;
                    if (p1 == 0) {
                        Console.WriteLine($"Player one is out of eggs. Player two has {p2} eggs left.");
                        return;
                    }
                }
            }
        }
    }
}