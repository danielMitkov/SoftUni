using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            int sum = 0;
            for (int i = 1; i <= n; ++i) {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num <= 5) {
                    p1 += num;
                } else if (num <= 12) {
                    p2 += num;
                } else if (num <= 25) {
                    p3 += num;
                } else if (num <= 40) {
                    p4 += num;
                } else if (num >= 41) {
                    p5 += num;
                }
            }
            p1 = p1 / sum * 100;
            p2 = p2 / sum * 100;
            p3 = p3 / sum * 100;
            p4 = p4 / sum * 100;
            p5 = p5 / sum * 100;
            Console.WriteLine($"{p1:F2}%\n{p2:F2}%\n{p3:F2}%\n{p4:F2}%\n{p5:F2}%");
        }
    }
}