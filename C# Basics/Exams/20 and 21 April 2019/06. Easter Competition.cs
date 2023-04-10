using System;
using System.Collections;

namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double b = double.Parse(Console.ReadLine());
            int a = 0;
            string w = "";
            for (int i = 1; i <= b; i++) {
                string n = Console.ReadLine();
                int t = 0;
                while (true) {
                    string text = Console.ReadLine();
                    if (text == "Stop") {
                        Console.WriteLine($"{n} has {t} points.");
                        if (t > a) {
                            Console.WriteLine($"{n} is the new number 1!");
                            a = t;
                            w = n;
                        }
                        break;
                    }
                    t += int.Parse(text);
                }
            }
            Console.WriteLine($"{w} won competition with {a} points!");
        }
    }
}