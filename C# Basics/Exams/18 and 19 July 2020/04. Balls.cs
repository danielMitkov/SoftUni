using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n = double.Parse(Console.ReadLine());
            double p = 0;
            double r = 0;
            double o = 0;
            double y = 0;
            double w = 0;
            double ot = 0;
            double di = 0;
            for (int i = 1; i <= n; i++) {
                switch (Console.ReadLine()) {
                    case "red":
                        p += 5;
                        r++;
                        break;
                    case "orange":
                        p += 10;
                        o++;
                        break;
                    case "yellow":
                        p += 15;
                        y++;
                        break;
                    case "white":
                        p += 20;
                        w++;
                        break;
                    case "black":
                        p = (int)Math.Floor(p / 2);
                        di++;
                        break;
                    default:
                        ot++;
                        break;
                }
            }
            Console.WriteLine($"Total points: {p}");
            Console.WriteLine($"Red balls: {r}");
            Console.WriteLine($"Orange balls: {o}");
            Console.WriteLine($"Yellow balls: {y}");
            Console.WriteLine($"White balls: {w}");
            Console.WriteLine($"Other colors picked: {ot}");
            Console.WriteLine($"Divides from black balls: {di}");
        }
    }
}