using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n = double.Parse(Console.ReadLine());
            double r = n * 1.31;
            Console.WriteLine($"{r:f3}");
        }
    }
}