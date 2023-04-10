using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string n = Console.ReadLine();
            double a = 301;
            double u = 0;
            double s = 0;
            while (true) {
                string t = Console.ReadLine();
                if (t == "Retire") {
                    Console.WriteLine($"{n} retired after {u} unsuccessful shots.");
                    return;
                }
                double p = double.Parse(Console.ReadLine());
                switch (t) {
                    case "Single":
                        if (a - p >= 0) {
                            a -= p;
                            s++;
                        } else {
                            u++;
                        }
                        break;
                    case "Double":
                        if (a - p * 2 >= 0) {
                            a -= p * 2;
                            s++;
                        } else {
                            u++;
                        }
                        break;
                    case "Triple":
                        if (a - p * 3 >= 0) {
                            a -= p * 3;
                            s++;
                        } else {
                            u++;
                        }
                        break;
                }
                if (a == 0) {
                    Console.WriteLine($"{n} won the leg with {s} shots.");
                    return;
                }
            }
        }
    }
}