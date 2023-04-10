using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double b = double.Parse(Console.ReadLine());
            int c = 0;
            int d = 1;
            double pt = 0;
            while (true) {
                string i = Console.ReadLine();
                if (i == "Stop") {
                    Console.WriteLine($"You bought {c} products for {pt:f2} leva.");
                    return;
                }
                double p = double.Parse(Console.ReadLine());
                if (d == 3) {
                    p /= 2;
                    d = 1;
                } else {
                    d++;
                }
                if (p + pt <= b) {
                    pt += p;
                    c++;
                } else {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {p + pt - b:f2} leva!");
                    return;
                }
            }
        }
    }
}