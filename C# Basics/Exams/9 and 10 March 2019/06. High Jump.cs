using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int h = int.Parse(Console.ReadLine());
            int hc = h - 30;
            int c = 0;
            int j = 0;
            while (true) {
                int t = int.Parse(Console.ReadLine());
                if (t > hc) {
                    j++;
                    if (hc == h) {
                        Console.WriteLine($"Tihomir succeeded, he jumped over {hc}cm after {j} jumps.");
                        return;
                    }
                    hc += 5;
                    c = 0;
                } else {
                    c++;
                    j++;
                    if (c == 3) {
                        Console.WriteLine($"Tihomir failed at {hc}cm after {j} jumps.");
                        return;
                    }
                }
            }
        }
    }
}