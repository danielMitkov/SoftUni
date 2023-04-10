using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string n = Console.ReadLine();
            double s = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());
            double t = double.Parse(Console.ReadLine());
            double a = t * 0.2;
            double f = a + t;
            double p = s * 10;
            double z = f * e * s + p;
            Console.WriteLine($"Total time needed to watch the {n} series is {z} minutes.");
        }
    }
}