using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double m = double.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());
            for(int i = 1; i <= n; ++i) {
                string t = Console.ReadLine();
                double p = double.Parse(Console.ReadLine());
                switch (t) {
                    case "Thrones":
                        p -= p * 0.5;
                        break;
                    case "Lucifer":
                        p -= p * 0.4;
                        break;
                    case "Protector":
                        p -= p * 0.3;
                        break;
                    case "TotalDrama":
                        p -= p * 0.2;
                        break;
                    case "Area":
                        p -= p * 0.1;
                        break;
                }
                m -= p;
            }
            if (m < 0) {
                Console.WriteLine($"You need {Math.Abs(m):f2} lv. more to buy the series!");
            } else {
                Console.WriteLine($"You bought all the series and left with {m:f2} lv.");
            }
        }
    }
}