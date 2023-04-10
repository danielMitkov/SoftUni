using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n = double.Parse(Console.ReadLine());
            double b = 0;
            double c = 0;
            double l = 0;
            double a = 0;
            double ps = 0;
            double pb = 0;
            for(int i = 1; i <= n; ++i) {
                string t = Console.ReadLine();
                switch (t) {
                    case "Back":
                        b++;
                        break;
                    case "Chest":
                        c++;
                        break;
                    case "Legs":
                        l++;
                        break;
                    case "Abs":
                        a++;
                        break;
                    case "Protein shake":
                        ps++;
                        break;
                    case "Protein bar":
                        pb++;
                        break;
                }
            }
            double sum = b + c + l + a + ps + pb;
            double tr = (b + c + l + a) / sum * 100;
            double pro = (ps + pb) / sum * 100;
            Console.WriteLine($"{b} - back");
            Console.WriteLine($"{c} - chest");
            Console.WriteLine($"{l} - legs");
            Console.WriteLine($"{a} - abs");
            Console.WriteLine($"{ps} - protein shake");
            Console.WriteLine($"{pb} - protein bar");
            Console.WriteLine($"{tr:f2}% - work out");
            Console.WriteLine($"{pro:f2}% - protein");
        }
    }
}