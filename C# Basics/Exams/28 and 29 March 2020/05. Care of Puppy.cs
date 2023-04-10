using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double food = double.Parse(Console.ReadLine());
            while(true) {
                string text = Console.ReadLine();
                if (text == "Adopted") {
                    if (food >= 0) {
                        Console.WriteLine($"Food is enough! Leftovers: {food * 1000} grams.");
                    } else {
                        Console.WriteLine($"Food is not enough. You need {Math.Abs(food) * 1000} grams more.");
                    }
                    return;
                }
                food -= double.Parse(text) / 1000;
            }
        }
    }
}