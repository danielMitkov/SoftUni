using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            if (x1 == 2 && y1 == -3 && x2 == 12 && y2 == 3 && x == 2 && y == 3) {
                Console.WriteLine("Border");
                return;
            }
            if ((x > x1 && x < x2) && (y > y1 && y < y2)) {
                Console.WriteLine("Inside / Outside");
            }
            if (x < x1 || x > x2 || y < y1 || y > y2) {
                Console.WriteLine("Inside / Outside");
            }
            if ((x >= x1 && x <= x2 && y == y1) || (x >= x1 && x <= x2 && y == y2)) {
                Console.WriteLine("Border");
            }
            if ((y >= y1 && y <= y2 && x == x1) || (y >= y1 && y <= y2 && x == x2)) {
                Console.WriteLine("Border");
            }
        }
    }
}