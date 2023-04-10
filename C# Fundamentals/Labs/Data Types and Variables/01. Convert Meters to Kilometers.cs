using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n = double.Parse(Console.ReadLine());
            double r = n / 1000;
            Console.WriteLine($"{r:f2}");
        }
    }
}