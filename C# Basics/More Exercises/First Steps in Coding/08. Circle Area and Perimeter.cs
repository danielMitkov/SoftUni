using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            double para = 2 * Math.PI * r;
            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{para:f2}");
        }
    }
}