using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double a1 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());
            for (double a = a1; a <= a2 - 1; ++a) {
                for (double b = 1; b <= n - 1; ++b) {
                    for (double c = 1; c <= n / 2 - 1; ++c) {
                        double d = (char)a;
                        if (a % 2 != 0 && (b + c + d) % 2 != 0) {
                            Console.WriteLine($"{(char)a}-{b}{c}{d}");
                        }
                    }
                }
            }
        }
    }
}