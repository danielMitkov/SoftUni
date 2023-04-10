using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int days = int.Parse(Console.ReadLine());
            double foodAll = int.Parse(Console.ReadLine());
            double foodDog = double.Parse(Console.ReadLine()) * days;
            double foodCat = double.Parse(Console.ReadLine()) * days;
            double foodTurtle = double.Parse(Console.ReadLine()) / 1000.0 * days;
            foodAll -= foodDog + foodCat + foodTurtle;
            if (foodAll >= 0) {
                Console.WriteLine($"{Math.Floor(foodAll)} kilos of food left.");
            } else {
                Console.WriteLine($"{Math.Ceiling(Math.Abs(foodAll))} more kilos of food are needed.");
            }
        }
    }
}