using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double ta = double.Parse(Console.ReadLine());
            double co = double.Parse(Console.ReadLine());
            double t = double.Parse(Console.ReadLine());
            double a = ta * 0.15;
            double b = co * t;
            double c = a + b;
            if (ta >= c) {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(ta - c)} minutes left!");
            } else {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(c - ta)} minutes.");
            }
        }
    }
}