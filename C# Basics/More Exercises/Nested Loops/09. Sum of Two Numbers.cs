using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = a; i <= b; i++) {
                for (int n = a; n <= b; ++n) {
                    count++;
                    if (i + n == c) {
                        Console.Write($"Combination N:{count} ({i} + {n} = {c})");
                        return;
                    }
                }
            }
            Console.Write($"{count} combinations - neither equals {c}");
        }
    }
}