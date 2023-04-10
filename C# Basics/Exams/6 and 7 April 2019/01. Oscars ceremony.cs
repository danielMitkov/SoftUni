using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double n = double.Parse(Console.ReadLine());
            double statues = n * 0.7;
            double food = statues * 0.85;
            double music = food / 2.0;
            double price = statues + food + music + n;
            Console.WriteLine($"{price:f2}");
        }
    }
}