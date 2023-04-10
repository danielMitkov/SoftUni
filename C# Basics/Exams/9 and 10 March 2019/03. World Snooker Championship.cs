using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string e = Console.ReadLine();
            string t = Console.ReadLine();
            double c = double.Parse(Console.ReadLine());
            double cc = 0;
            bool p = Console.ReadLine() == "Y" ? true : false;
            switch (e) {
                case "Quarter final":
                    cc = getSC(t, 55.5, 105.2, 118.9) * c;
                    break;
                case "Semi final":
                    cc = getSC(t, 75.88, 125.22, 300.4) * c;
                    break;
                case "Final":
                    cc = getSC(t, 110.1, 160.66, 400) * c;
                    break;
            }
            bool free = false;
            if(cc > 4000) {
                cc -= cc * 0.25;
                free = true;
            }else if(cc > 2500) {
                cc -= cc * 0.1;
            }
            if (p && !free) {
                cc += 40 * c;
            }
            Console.WriteLine($"{cc:f2}");
        }
        static double getSC(string u, double a, double b, double c) {
            double r = 0;
            if (u == "Standard") {
                r = a;
            }
            if (u == "Premium") {
                r = b;
            }
            if (u == "VIP") {
                r = c;
            }
            return r;
        }
    }
}