using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double p2 = double.Parse(Console.ReadLine());
            double k = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double a = 0;
            if (k < 10) {
                a = p2 * 0.2;
            } else if (k >= 10 && k <= 20) {
                a = p2 * 0.5;
            } else if(k > 20) {
                a = p2;
            }
            if (d < 7) {
                a += a * 0.4;
            } else if (d >= 7 && d <= 30) {
                a += a * 0.15;
            } else if (d > 30) {
                a += a * 0.1;
            }

            Console.WriteLine($"The total price of bags is: {a * b:f2} lv.");
        }
    }
}