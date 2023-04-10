using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            var number = int.Parse(Console.ReadLine());
            for (byte i = 1; i <= 10; i++) {
                Console.WriteLine($"{number} X {i} = {number * i}");
            }
        }
    }
}