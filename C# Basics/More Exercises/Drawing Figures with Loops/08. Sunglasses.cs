using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int a = int.Parse(Console.ReadLine());
            for (int i = 1; i <= a; ++i) {
                for (int m = 1; m <= a * 2; ++m) {
                    if ((i == 1 || i == a) || ((i != 1 || i != a) && (m == 1 || m == a * 2))) {
                        Console.Write("*");
                    } else {
                        Console.Write("/");
                    }
                }
                if (i == Math.Ceiling(a / 2.0)) {
                    for (int l = 1; l <= a; ++l) {
                        Console.Write("|");
                    }
                } else{
                    for (int l = 1; l <= a; ++l) {
                        Console.Write(" ");
                    }
                }
                for (int m = 1; m <= a * 2; ++m) {
                    if ((i == 1 || i == a) || ((i != 1 || i != a) && (m == 1 || m == a * 2))) {
                        Console.Write("*");
                    } else {
                        Console.Write("/");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}