using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string t = Console.ReadLine();
            double n = double.Parse(Console.ReadLine());
            int w = 0;
            int d = 0;
            int l = 0;
            int p = 0;
            if (n <= 0) {
                Console.WriteLine($"{t} hasn't played any games during this season.");
                return;
            }
            for (int i = 1; i <= n; ++i) {
                string match = Console.ReadLine();
                switch (match) {
                    case "W":
                        w++;
                        p += 3;
                        break;
                    case "D":
                        d++;
                        p++;
                        break;
                    case "L":
                        l++;
                        break;
                }
            }
            Console.WriteLine($"{t} has won {p} points during this season.");
            Console.WriteLine("Total stats:");
            Console.WriteLine($"## W: {w}");
            Console.WriteLine($"## D: {d}");
            Console.WriteLine($"## L: {l}");
            Console.WriteLine($"Win rate: {w / n * 100:f2}%");
        }
    }
}