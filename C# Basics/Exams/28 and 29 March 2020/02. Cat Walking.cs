using System;
namespace SoftUni {
    class Program {
        static void Main(string[] args) {
            double m = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double k = double.Parse(Console.ReadLine());
            m *= b * 5;
            if (m >= k * 0.5) {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {m}.");
            } else {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {m}.");
            }
        }
    }
}