using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int w = 0;
            int l = 0;
            double ga = 0;
            while (true) {
                string t = Console.ReadLine();
                if (t == "End of tournaments") {
                    Console.WriteLine($"{w / ga * 100:f2}% matches win");
                    Console.WriteLine($"{l / ga * 100:f2}% matches lost");
                    return;
                }
                double g = 0;
                for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
                    double f = double.Parse(Console.ReadLine());
                    double s = double.Parse(Console.ReadLine());
                    string r = f > s ? "win" : "lost";
                    g++;
                    Console.WriteLine($"Game {g} of tournament {t}: {r} with {Math.Abs(f - s)} points.");
                    ga++;
                    if (r == "win") {
                        w++;
                    } else {
                        l++;
                    }
                }
            }
        }
    }
}