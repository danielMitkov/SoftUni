using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string town = Console.ReadLine();
            double pop = double.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());
            Console.WriteLine($"Town {town} has population of {pop} and area {area} square km.");
        }
    }
}