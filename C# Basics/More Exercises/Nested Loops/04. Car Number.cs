using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int s = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            for (int a = s; a <= f; a++) {
                for (int b = s; b <= f; ++b) {
                    for (int c = s; c <= f; ++c) {
                        for (int d = s; d <= f; ++d) {
                            if ((a % 2 == 0 && d % 2 != 0) || (d % 2 == 0 && a % 2 != 0)) {
                                if (a > d && ((b + c) % 2 == 0)) {
                                    Console.Write($"{a}{b}{c}{d} ");
                                }
                                
                            }
                        }
                    }
                }
            }
        }
    }
}