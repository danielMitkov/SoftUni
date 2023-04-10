using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int students = int.Parse(Console.ReadLine());
            double sum = 0;
            double count = 0;
            double n0 = 0;
            double n1 = 0;
            double n2 = 0;
            double n3 = 0;
            double n4 = 0;
            double n5 = 0;
            for (int i = 1; i <= students; ++i) {
                double num = double.Parse(Console.ReadLine());
                count++;
                if (num >= 0 && num <= 9) {
                    sum += num * 0.2;
                    n0++;
                } else if (num >= 10 && num <= 19) {
                    sum += num * 0.3;
                    n1++;
                } else if (num >= 20 && num <= 29) {
                    sum += num * 0.4;
                    n2++;
                } else if (num >= 30 && num <= 39) {
                    sum += 50;
                    n3++;
                } else if (num >= 40 && num <= 50) {
                    sum += 100;
                    n4++;
                } else if (num < 0 || num > 50) {
                    sum /= 2;
                    n5++;
                }
            }
            double avg = sum / count;
            n0 = n0 / count * 100;
            n1 = n1 / count * 100;
            n2 = n2 / count * 100;
            n3 = n3 / count * 100;
            n4 = n4 / count * 100;
            n5 = n5 / count * 100;

            Console.WriteLine($"{sum:f2}");
            Console.WriteLine($"From 0 to 9: {n0:f2}%");
            Console.WriteLine($"From 10 to 19: {n1:f2}%");
            Console.WriteLine($"From 20 to 29: {n2:f2}%");
            Console.WriteLine($"From 30 to 39: {n3:f2}%");
            Console.WriteLine($"From 40 to 50: {n4:f2}%");
            Console.WriteLine($"Invalid numbers: {n5:f2}%");
        }
    }
}