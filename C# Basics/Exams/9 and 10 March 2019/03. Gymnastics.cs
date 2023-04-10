using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string c = Console.ReadLine();
            string u = Console.ReadLine();
            double s = 0;
            switch (c) {
                case "Russia":
                    s = getSC(u, 18.5, 19.1, 18.6);
                    break;
                case "Bulgaria":
                    s = getSC(u, 19, 19.3, 18.9);
                    break;
                case "Italy":
                    s = getSC(u, 18.7, 18.8, 18.85);
                    break;
            }
            Console.WriteLine($"The team of {c} get {s:f3} on {u}.");
            Console.WriteLine($"{(100 - (s/20*100)):f2}%");
        }
        static double getSC(string u, double a, double b, double c) {
            double r = 0;
            if (u == "ribbon") {
                r = a;
            }
            if (u == "hoop") {
                r = b;
            }
            if (u == "rope") {
                r = c;
            }
            return r;
        }
    }
}