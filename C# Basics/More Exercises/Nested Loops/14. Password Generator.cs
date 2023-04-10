using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine()) + 96;
            for (int a = 1; a <= n; a++) {
                for (int b = 1; b <= n; ++b) {
                    for (int c = 97; c <= l; ++c) {
                        for (int d = 97; d <= l; ++d) {
                            for (int e = 1; e <= n; ++e) {
                                if (e > a && e > b) {
                                    Console.Write($"{a}{b}{(char)c}{(char)d}{e} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}