using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            bool o = Console.ReadLine() == "one" ? true : false;
            string t = Console.ReadLine();
            bool y = Console.ReadLine() == "yes" ? true : false;
            double c = double.Parse(Console.ReadLine());
            double p = 0;
            switch (t) {
                case "Small":
                    p = o ? 9.98 : 8.58;
                    break;
                case "Middle":
                    p = o ? 18.99 : 17.09;
                    break;
                case "Large":
                    p = o ? 25.98 : 23.59;
                    break;
                case "ExtraLarge":
                    p = o ? 35.99 : 31.79;
                    break;
            }
            if (y) {
                if (p <= 10) {
                    p += 5.5;
                } else if (p <= 30) {
                    p += 4.35;
                } else if (p > 30) {
                    p += 3.85;
                }
            }
            p *= c;
            if (!o) {
                p -= p * 0.0375;
            }
            Console.WriteLine($"{p:f2} lv.");
        }
    }
}