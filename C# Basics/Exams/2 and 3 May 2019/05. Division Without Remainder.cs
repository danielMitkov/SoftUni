using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            for (int i = n; i > 0; --i) {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0) {
                    ++p1;
                }
                if (num % 3 == 0) {
                    ++p2;
                }
                if (num % 4 == 0) {
                    ++p3;
                }
            }
            p1 = p1 / n * 100;
            p2 = p2 / n * 100;
            p3 = p3 / n * 100;
            Console.WriteLine($"{p1:F2}%\n{p2:F2}%\n{p3:F2}%");
        }
    }
}