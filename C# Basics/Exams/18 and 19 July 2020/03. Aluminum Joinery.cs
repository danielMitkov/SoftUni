using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double b = double.Parse(Console.ReadLine());
            string t = Console.ReadLine();
            bool d = Console.ReadLine() == "With delivery" ? true : false;
            double p = 0;
            switch (t) {
                case "90X130":
                    p = get(b, 110, 30, 60, 5, 8);
                    break;
                case "100X150":
                    p = get(b, 140, 40, 80, 6, 10);
                    break;
                case "130X180":
                    p = get(b, 190, 20, 50, 7, 12);
                    break;
                case "200X300":
                    p = get(b, 250, 25, 50, 9, 14);
                    break;
            }
            if (d) {
                p += 60;
            }
            if(b >= 100) {
                p -= p * 0.04;
            }
            if (b < 10) {
                Console.WriteLine("Invalid order");
                return;
            }
            Console.WriteLine($"{p:f2} BGN");
        }
        static double get(double b, double c, double d1, double d2, double p1, double p2) {
            double p = b * c;
            if (b > d2) {
                p -= p * p2/100.0;
            }else if (b > d1) {
                p -= p * p1/100.0;
            }
            return p;
        }
    }
}