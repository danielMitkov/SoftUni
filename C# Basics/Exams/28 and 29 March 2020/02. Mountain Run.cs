using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double r = double.Parse(Console.ReadLine());
            double s = double.Parse(Console.ReadLine());
            double t = double.Parse(Console.ReadLine());
            double a = s * t;
            double b = Math.Floor(s / 50) * 30;
            double c = a + b;
            if (c < r) {
                Console.WriteLine($"Yes! The new record is {c:f2} seconds.");
            } else {
                Console.WriteLine($"No! He was {c - r:f2} seconds slower.");
            }
        }
    }
}