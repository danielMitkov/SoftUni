using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            for (int first = start; first <= finish; ++first) {
                int sumEven = 0;
                int sumOdd = 0;
                for (int pos = 0; pos < first.ToString().Length; ++pos) {
                    char num = first.ToString()[pos];
                    if ((pos + 1) % 2 == 0) { 
                        sumEven += num;
                    } else {
                        sumOdd += num;
                    }
                }
                if (sumEven == sumOdd) {
                    Console.Write(first + " ");
                }
            }
        }
    }
}