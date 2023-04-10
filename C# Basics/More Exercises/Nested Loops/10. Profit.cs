using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int m1 = int.Parse(Console.ReadLine());
            int m2 = int.Parse(Console.ReadLine());
            int m5 = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            for (int a = 0; a <= m1; a++) {
                for (int b = 0; b <= m2; ++b) {
                    for (int c = 0; c <= m5; ++c) {
                        if (a * 1 + b * 2 + c * 5 == s) {
                            Console.WriteLine($"{a} * 1 lv. + {b} * 2 lv. + {c} * 5 lv. = {s} lv.");                        
                        }
                    }
                }
            }
        }
    }
}