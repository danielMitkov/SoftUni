using System;
using System.Collections;

namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double c = double.Parse(Console.ReadLine());
            double a = 0;
            for (int z = 1; z <= c; z++) {
                double p = 0;
                int n = 0;
                while (true) {
                    string i = Console.ReadLine();
                    if (i == "Finish") {
                        break;
                    }
                    n++;
                    switch (i) {
                        case "basket":
                            p += 1.5;
                            break;
                        case "wreath":
                            p += 3.8;
                            break;
                        case "chocolate bunny":
                            p += 7;
                            break;
                    }
                }
                if (n % 2 == 0) {
                    p -= p * 0.2;
                }
                Console.WriteLine($"You purchased {n} items for {p:f2} leva.");
                a += p;
            }
            Console.WriteLine($"Average bill per client is: {a / c:f2} leva.");
        }
    }
}