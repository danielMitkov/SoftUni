using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double m = double.Parse(Console.ReadLine());
            string p = Console.ReadLine();
            bool isSu = Console.ReadLine() == "Summer" ? true : false;
            double d = double.Parse(Console.ReadLine());
            double z = 0;
            switch (p) {
                case "Dubai":
                    z = Getz(isSu, 45000, 40000);
                    z *= d;
                    z -= z * 0.3;
                    break;
                case "Sofia":
                    z = Getz(isSu, 17000, 12500);
                    z *= d;
                    z += z * 0.25;
                    break;
                case "London":
                    z = Getz(isSu, 24000, 20250);
                    z *= d;
                    break;
            }
            if (m >= z) {
                Console.WriteLine($"The budget for the movie is enough! We have {m - z:f2} leva left!");
            } else {
                Console.WriteLine($"The director needs {z - m:f2} leva more!");
            }
        }
        static double Getz(bool isSu, double a, double b) {
            if (!isSu) {
                return a;
            }
            if (isSu) {
                return b;
            }
            return 0;
        }
    }
}