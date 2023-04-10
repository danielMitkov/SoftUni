using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double k = double.Parse(Console.ReadLine());
            double e = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine()); ;
            double t = 0;
            k *= 3.2;
            double et = e * 12;
            et *= 0.15;
            e *= 4.35;
            e += et;
            c *= 5.4;
            t = e + c + k;
            Console.WriteLine($"{t:f2}");
        }
    }
}