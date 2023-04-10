using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double h = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            double surfice = h * w * 4;
            double forPaint = Math.Ceiling(surfice - surfice * (p / 100));
            while (true) {
                string l = Console.ReadLine();
                if (l == "Tired!") {
                    Console.WriteLine($"{forPaint} quadratic m left.");
                    return;
                }
                forPaint -= double.Parse(l);
                if (forPaint == 0) {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                    return;
                }
                if (forPaint <= 0) {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(forPaint)} l paint left!");
                    return;
                }
            }
        }
    }
}