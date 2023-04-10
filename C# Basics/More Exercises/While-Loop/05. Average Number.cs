using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= n; ++i) {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"{sum / n:f2}");
        }
    }
}