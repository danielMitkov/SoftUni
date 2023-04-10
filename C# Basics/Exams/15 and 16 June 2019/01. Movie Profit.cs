using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string n = Console.ReadLine();
            double d = double.Parse(Console.ReadLine());
            double t = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            double a = t * c;
            double b = d * a;
            double c2 = b * p / 100;
            double z = b - c2;
            Console.WriteLine($"The profit from the movie {n} is {z:f2} lv.");
        }
    }
}