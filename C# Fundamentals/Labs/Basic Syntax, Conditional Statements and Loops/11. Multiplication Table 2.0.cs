using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            var number = byte.Parse(Console.ReadLine());
            var multiplier = byte.Parse(Console.ReadLine());
            do {
                Console.WriteLine($"{number} X {multiplier} = {number * multiplier}");
                multiplier++;
            } while (multiplier <= 10);
        }
    }
}