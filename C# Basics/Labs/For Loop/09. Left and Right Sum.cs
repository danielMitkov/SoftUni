using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int sumFirst = 0;
            int sumSecond = 0;
            int n = int.Parse(Console.ReadLine()) * 2;
            for (int i = n / 2; i > 0; --i) {
                sumFirst += int.Parse(Console.ReadLine());
            }
            for (int i = n / 2; i > 0; --i) {
                sumSecond += int.Parse(Console.ReadLine());
            }
            if (sumFirst == sumSecond) {
                Console.WriteLine($"Yes, sum = {sumFirst}");
            } else {
                Console.WriteLine($"No, diff = {Math.Abs(sumFirst - sumSecond)}");
            }
        }
    }
}