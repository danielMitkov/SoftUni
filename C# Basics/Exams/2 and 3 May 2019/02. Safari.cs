using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double b = double.Parse(Console.ReadLine());
            double l = double.Parse(Console.ReadLine());
            bool sa = Console.ReadLine() == "Saturday" ? true : false; ;
            double p = l * 2.1 + 100;
            if (sa) {
                p -= p * 0.1;
            } else {
                p -= p * 0.2;
            }
            if (b >= p) {
                Console.WriteLine($"Safari time! Money left: {b - p:F2} lv. ");
            } else {
                Console.WriteLine($"Not enough money! Money needed: {p - b:f2} lv.");
            }

        }
    }
}