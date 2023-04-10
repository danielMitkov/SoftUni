using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            int min = int.MaxValue;
            while (input != "Stop") {
                min = int.Parse(input) < min ? int.Parse(input) : min;
                input = Console.ReadLine();
            }
            Console.WriteLine(min);
        }
    }
}