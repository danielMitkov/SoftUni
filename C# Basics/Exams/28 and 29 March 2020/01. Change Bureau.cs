using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double b = double.Parse(Console.ReadLine());
            double k = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine()) * 0.01;
            double alleuro = (k * 0.15 * 1.76 + b * 1168) / 1.95;
            double charge = alleuro * c;
            double result = alleuro - charge;
            Console.WriteLine($"{result:f2}");
        }
    }
}