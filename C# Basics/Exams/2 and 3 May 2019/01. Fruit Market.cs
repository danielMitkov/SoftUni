using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double strawP = double.Parse(Console.ReadLine());
            double banC = double.Parse(Console.ReadLine());
            double portC = double.Parse(Console.ReadLine());
            double malC = double.Parse(Console.ReadLine());
            double strawC = double.Parse(Console.ReadLine());
            double malP = strawP / 2;
            double portP = malP - malP * 0.4;
            double banP = malP - malP * 0.8;
            double p = strawP * strawC + banP * banC + portP * portC + malP * malC;
            Console.WriteLine($"{p:f2}");
        }
    }
}