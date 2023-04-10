using System;
using System.Collections;

namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double breads = double.Parse(Console.ReadLine());
            int totalSugar = 0;
            int totalFlour = 0;
            double maxSugar = 0;
            double maxFlour = 0;
            for (int i = 1; i <= breads; i++) {
                double sugar = double.Parse(Console.ReadLine());
                double flour = double.Parse(Console.ReadLine());
                if (sugar > maxSugar) {
                    maxSugar = sugar;
                }
                if (flour > maxFlour) {
                    maxFlour = flour;
                }
                totalSugar += (int)sugar;
                totalFlour += (int)flour;
            }
            totalSugar = (int)Math.Ceiling(totalSugar / 950.0);
            totalFlour = (int)Math.Ceiling(totalFlour / 750.0);
            Console.WriteLine($"Sugar: {totalSugar}");
            Console.WriteLine($"Flour: {totalFlour}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}