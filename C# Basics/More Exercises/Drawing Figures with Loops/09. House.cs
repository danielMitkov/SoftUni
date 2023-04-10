using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            int st = a % 2 == 0 ? 2 : 1;
            bool isA = false;
            for (int i = 1; i <= a; ++i) {
                int min = a - st;
                for (int ni = 1; ni <= min / 2; ++ni) {
                    Console.Write("-");
                }
                if (st == a && isA) {
                    Console.Write("|");
                    for (int m = 1; m <= st - 2; ++m) {
                        Console.Write("*");
                    }
                    Console.Write("|");
                } else {
                    for (int m = 1; m <= st; ++m) {
                        Console.Write("*");
                    }
                }
                for (int ni = 1; ni <= min / 2; ++ni) {
                    Console.Write("-");
                }
                if (st == a) {
                    isA = true;
                }
                st += st < a ? 2 : 0;
                Console.WriteLine();
            }
        }
    }
}