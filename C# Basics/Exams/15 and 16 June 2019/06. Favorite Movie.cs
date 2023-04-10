using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string m = "";
            double a = 0;
            for(int i = 1; i <= 7; ++i) {
                string f = Console.ReadLine();
                if (f == "STOP") {
                    break;
                }
                double v = 0;
                double s = 0;
                double b = 0;
                for (int k = 0; k < f.Length; ++k) {
                    v += (char)f[k];
                    if ((char)f[k] >= 97 && (char)f[k] <= 122) {
                        s++;
                    }
                    if ((char)f[k] >= 65 && (char)f[k] <= 90) {
                        b++;
                    }
                }
                if (s > 0) {
                    v -= (f.Length * 2) * s;
                }
                if (b > 0) {
                    v -= f.Length * b;
                }
                if (v > a) {
                    a = v;
                    m = f;
                }
                if (i == 7) {
                    Console.WriteLine("The limit is reached.");
                }
            }
            Console.WriteLine($"The best movie for you is {m} with {a} ASCII sum.");
        }
    }
}