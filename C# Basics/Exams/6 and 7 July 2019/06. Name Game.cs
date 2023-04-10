using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string w = "";
            int p = 0;
            while (true) {
                string wt = Console.ReadLine();
                if (wt == "Stop") {
                    break;
                }
                int pt = 0;
                for (int i = 0; i < wt.Length; ++i) {
                    if (int.Parse(Console.ReadLine()) == (char)wt[i]) {
                        pt += 10;
                    } else {
                        pt += 2;
                    }
                }
                if (pt >= p) {
                    w = wt;
                    p = pt;
                }
            }
            Console.WriteLine($"The winner is {w} with {p} points!");
        }
    }
}