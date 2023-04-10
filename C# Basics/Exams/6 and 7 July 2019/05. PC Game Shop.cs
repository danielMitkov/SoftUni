using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n = double.Parse(Console.ReadLine());
            int stone = 0;
            int fort = 0;
            int over = 0;
            int other = 0;
            for (int i = 1; i <= n; ++i) {
                string game = Console.ReadLine();
                switch (game) {
                    case "Hearthstone":
                        stone++;
                        break;
                    case "Fornite":
                        fort++;
                        break;
                    case "Overwatch":
                        over++;
                        break;
                    default:
                        other++;
                        break;
                }
            }
            Console.WriteLine($"Hearthstone - {stone / n * 100:f2}%");
            Console.WriteLine($"Fornite - {fort / n * 100:f2}%");
            Console.WriteLine($"Overwatch - {over / n * 100:f2}%");
            Console.WriteLine($"Others - {other / n * 100:f2}%");
        }
    }
}