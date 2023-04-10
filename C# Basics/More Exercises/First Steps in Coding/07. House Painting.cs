using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double wallSide = x * y;
            double window = 1.5 * 1.5;
            double wallTwoSide = 2 * wallSide - 2 * window;

            double wallBack = x * x;
            double door = 1.2 * 2;
            double wallTwoFront = 2 * wallBack - door;

            double green = (wallTwoFront + wallTwoSide) / 3.4;


            double roofTwoRac = 2 * (x * y);
            double roofTwoTri = 2 * (x * h / 2);

            double red = (roofTwoRac + roofTwoTri) / 4.3;
            Console.WriteLine($"{green:f2}");
            Console.WriteLine($"{red:f2}");
        }
    }
}