using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string n = Console.ReadLine();
            double ta = double.Parse(Console.ReadLine());
            double tc = double.Parse(Console.ReadLine());
            double tp = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            double a = tp - tp * 0.7;
            double b = tp + p;
            double c = a + p;
            double d = (tc * c) + (ta * b);
            double e = d * 0.2;
            Console.WriteLine($"The profit of your agency from {n} tickets is {e:f2} lv.");
        }
    }
}