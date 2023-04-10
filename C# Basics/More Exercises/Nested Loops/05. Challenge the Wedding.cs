using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int m = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int o = int.Parse(Console.ReadLine());
            for (int a = 1; a <= m; a++) {
                for (int b = 1; b <= w; ++b) {
                    Console.Write($"({a} <-> {b}) ");
                    o--;
                    if(o == 0) {
                        return;
                    }
                }
            }
        }
    }
}