using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double evenSum = 0;
            double oddMin = double.MaxValue;
            double evenMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenMax = double.MinValue;
            bool hasOddMin = false;
            bool hasEvenMin = false;
            bool hasOddMax = false;
            bool hasEvenMax = false;
            for (int i = 1; i <= n; ++i) {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0) {
                    evenSum += num;
                    if (num < evenMin) {
                        evenMin = num;
                        hasEvenMin = true;
                    }
                    if (num > evenMax) {
                        evenMax = num;
                        hasEvenMax = true;
                    }
                } else {
                    oddSum += num;
                    if (num < oddMin) {
                        oddMin = num;
                        hasOddMin = true;
                    }
                    if (num > oddMax) {
                        oddMax = num;
                        hasOddMax = true;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (hasOddMin) {
                Console.WriteLine($"OddMin={oddMin:f2},");
            } else {
                Console.WriteLine($"OddMin=No,");
            }
            if (hasOddMax) {
                Console.WriteLine($"OddMax={oddMax:f2},");
            } else {
                Console.WriteLine($"OddMax=No,");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (hasEvenMin) {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            } else {
                Console.WriteLine($"EvenMin=No,");
            }
            if (hasEvenMax) {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            } else {
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}