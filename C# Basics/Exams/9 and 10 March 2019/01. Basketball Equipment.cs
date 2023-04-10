using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int cost = int.Parse(Console.ReadLine());

            double shoes = cost * 0.6;
            double clothes = shoes * 0.8;
            double ball = clothes / 4;
            double other = ball / 5;

            Console.WriteLine($"{cost + shoes + clothes + ball + other:f2}");
        }
    }
}