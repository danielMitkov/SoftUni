using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            for (int j = 1; j <= a; ++j) {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
            for (int i = a; i >= 1; --i) {
                for (int s = 1; s <= i - 1; ++s) {
                    Console.Write(" ");
                }

                for (int m = 1; m <= a - i + 1; ++m) {
                    Console.Write("*");

                }
                Console.Write(" | ");
                for (int m = 1; m <= a - i + 1; ++m) {
                    Console.Write("*");

                }
                Console.WriteLine();
            }
        }
    }
}