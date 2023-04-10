using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            for (int i = 1; i <= 10; ++i) {
                for (int m = 1; m <= 10; ++m) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}