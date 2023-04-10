using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int sumEven = 0;
            int sumOdd = 0;
            for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
                if (n % 2 == 0) {
                    sumEven += int.Parse(Console.ReadLine());
                } else {
                    sumOdd += int.Parse(Console.ReadLine());
                }
            }
            if (sumEven == sumOdd) {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            } else {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sumEven - sumOdd)}");
            }
        }
    }
}