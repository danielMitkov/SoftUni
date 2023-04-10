using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double r = double.Parse(Console.ReadLine());
            double br = double.Parse(Console.ReadLine());
            double bm = double.Parse(Console.ReadLine());
            double a = br * r;
            double b = r / 6;
            double c = bm * b;
            double d = (a + c) * 0.2;
            double e = a + c + d;
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(e / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(e * 7 / 8)}");
        }
    }
}