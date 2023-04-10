using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int o = n > 9 ? 9 : n;
            for (int a = 1; a <= o; a++) {
                for (int b = 1; b <= o; ++b) {
                    for (int v = 1; v <= o; ++v) {
                        for (int g = 1; g <= o; ++g) {
                            if (a + b == v + g && n % (a + b) == 0) {
                                Console.Write($"{a}{b}{v}{g} ");
                            }
                        }
                    }
                }
            }
        }
    }
}