using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            for (int i = a; i >= 1; --i) {
                for (int s = 1; s <= i - 2; ++s) {
                    Console.Write(" ");
                }
                for (int m = 1; m <= a - i + 1; ++m) {
                    if(i == 1 && m == 1) {
                        Console.Write("*");
                    } else {
                        Console.Write(" *");
                    }
                }
                Console.WriteLine();
            }
            for (int i = a - 1; i >= 1; --i) {
                for (int s = 1; s <= a - i - 1; ++s) {
                    Console.Write(" ");
                }
                for (int m = 1; m <= i; ++m) {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}