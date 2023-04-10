using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string w = Console.ReadLine();
            string r = "";
            int p = 0;
            while (w != "End of words") {
                int pt = 0;
                for (int i = 0; i < w.Length; ++i) {
                    pt += w[i];
                }
                if (w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u' || w[0] == 'y') {
                    pt *= w.Length;
                } else if (w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U' || w[0] == 'Y') {
                    pt *= w.Length;
                } else {
                    pt = (int)Math.Floor((double)pt/w.Length);
                }
                if (pt > p) {
                    r = w;
                    p = pt;
                }
                w = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {r} - {p}");
        }
    }
}