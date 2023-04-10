using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string name = Console.ReadLine();
            double sum = 0;
            bool badBefore = false;
            for (int year = 1; year <= 12; ++year) {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4) {
                    if (badBefore) {
                        Console.WriteLine($"{name} has been excluded at {year - 1} grade");
                        return;
                    }
                    badBefore = true;
                }
                sum += grade;
            }
            Console.WriteLine($"{name} graduated. Average grade: {(sum / 12):F2}");
        }
    }
}