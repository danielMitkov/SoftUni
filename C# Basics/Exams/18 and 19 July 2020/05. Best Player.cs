using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string n = "";
            double m = -4;
            while (true) {
                string i = Console.ReadLine();
                if (i == "END") {
                    Console.WriteLine($"{n} is the best player!");
                    if (m >= 3) {
                        Console.WriteLine($"He has scored {m} goals and made a hat-trick !!!");
                    } else {
                        Console.WriteLine($"He has scored {m} goals.");
                    }
                    return;
                }
                double g = double.Parse(Console.ReadLine());
                if (g >= 10) {
                    Console.WriteLine($"{i} is the best player!");
                    Console.WriteLine($"He has scored {g} goals and made a hat-trick !!!");
                    return;
                }
                if (g > m) {
                    n = i;
                    m = g;
                }
            }
        }
    }
}