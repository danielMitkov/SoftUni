using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int students = int.Parse(Console.ReadLine());
            double sum = 0;
            double count = 0;
            double g2 = 0;
            double g3 = 0;
            double g4 = 0;
            double g5 = 0;
            for (int i = 1; i <= students; ++i) {
                double grade = double.Parse(Console.ReadLine());
                sum += grade;
                count++;
                if (grade >= 2 && grade <= 2.99) {
                    g2++;
                } else if (grade >= 3 && grade <= 3.99) {
                    g3++;
                } else if (grade >= 4 && grade <= 4.99) {
                    g4++;
                } else if (grade >= 5) {
                    g5++;
                }
            }
            double avg = sum / count;
            g2 = g2 / count * 100;
            g3 = g3 / count * 100;
            g4 = g4 / count * 100;
            g5 = g5 / count * 100;
            
            Console.WriteLine($"Top students: {g5:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {g4:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {g3:f2}%");
            Console.WriteLine($"Fail: {g2:f2}%");
            Console.WriteLine($"Average: {avg:f2}");
        }
    }
}