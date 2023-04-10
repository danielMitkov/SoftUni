using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double m = double.Parse(Console.ReadLine());
            double s = double.Parse(Console.ReadLine());
            double dd = double.Parse(Console.ReadLine());
            double s1 = double.Parse(Console.ReadLine());
            double a = m * 60 + s;
            double b = dd / 120;
            double c = b * 2.5;
            double d = (dd / 100) * s1 - c;
            if (d > a) {
                Console.WriteLine($"No, Marin failed! He was {d - a:f3} second slower.");
            } else {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {d:f3}.");
            }
        }
    }
}