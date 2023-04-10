using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= a; ++i) {
                for (int m = 1; m <= a; ++m) {
                    if (m == 1 || m == a) {
                        if (i == 1 || i == a) {
                            Console.Write("+ ");
                            continue;
                        } else {
                            Console.Write("| ");
                            continue;
                        }
                    }
                    Console.Write("- ");
                }
                Console.WriteLine();
            }
        }
    }
}