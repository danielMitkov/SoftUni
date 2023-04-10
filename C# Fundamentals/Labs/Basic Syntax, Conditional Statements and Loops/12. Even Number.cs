using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            short number = Math.Abs(short.Parse(Console.ReadLine()));
            bool isEven = number % 2 == 0;
            while (!isEven) {
                Console.WriteLine("Please write an even number.");
                number = Math.Abs(short.Parse(Console.ReadLine()));
                isEven = number % 2 == 0;
            }
            Console.WriteLine($"The number is: {number}");
        }
    }
}