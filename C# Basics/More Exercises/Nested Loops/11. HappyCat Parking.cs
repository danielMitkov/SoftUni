using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double m1 = double.Parse(Console.ReadLine());
            double m2 = double.Parse(Console.ReadLine());
            double total = 0;
            for (int a = 1; a <= m1; a++) {
                double sum = 0;
                for (int b = 1; b <= m2; ++b) {
                    if (a % 2 == 0 && b % 2 != 0) {
                        sum += 2.5;
                    } else if (a % 2 != 0 && b % 2 == 0) {
                        sum += 1.25;
                    } else {
                        sum += 1;
                    }
                }
                total += sum;
                Console.WriteLine($"Day: {a} - {sum:f2} leva");
            }
            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}