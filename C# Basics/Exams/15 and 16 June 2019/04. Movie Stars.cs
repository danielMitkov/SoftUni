using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double c = double.Parse(Console.ReadLine());
            while (true) {
                string text = Console.ReadLine();
                if (text == "ACTION") {
                    Console.WriteLine($"We are left with {c:f2} leva.");
                    break;
                }
                if (text.Length > 15) {
                    c -= c * 0.2;
                    continue;
                }
                double p = double.Parse(Console.ReadLine());
                c -= p;
                if (c < 0) {
                    Console.WriteLine($"We need {Math.Abs(c):f2} leva for our actors.");
                    break;
                }
            }
        }
    }
}