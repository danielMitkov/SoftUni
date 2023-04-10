using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int capacity = int.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());
            double sum = 0;
            double count = 0;
            double fa = 0;
            double fb = 0;
            double fv = 0;
            double fg = 0;
            for (int i = 1; i <= fans; ++i) {
                string sector = Console.ReadLine();
                if (sector == "A") {
                    fa++;
                } else if (sector == "B") {
                    fb++;
                } else if (sector == "V") {
                    fv++;
                } else if (sector == "G") {
                    fg++;
                }
                count++;
            }
            fa = fa / fans * 100;
            fb = fb / fans * 100;
            fv = fv / fans * 100;
            fg = fg / fans * 100;
            double avg = fans / capacity * 100;
            Console.WriteLine($"{fa:f2}%");
            Console.WriteLine($"{fb:f2}%");
            Console.WriteLine($"{fv:f2}%");
            Console.WriteLine($"{fg:f2}%");
            Console.WriteLine($"{avg:f2}%");
        }
    }
}