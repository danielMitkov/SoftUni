using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int w = 0;
            int l = 0;
            int d = 0;
            for (int i = 1; i <= 3; ++i) {
                string m = Console.ReadLine();
                if ((char)m[0] > (char)m[2]) {
                    w++;
                }
                if ((char)m[0] < (char)m[2]) {
                    l++;
                }
                if ((char)m[0] == (char)m[2]) {
                    d++;
                }
            }
            Console.WriteLine($"Team won {w} games.");
            Console.WriteLine($"Team lost {l} games.");
            Console.WriteLine($" Drawn games: {d}");
        }
    }
}