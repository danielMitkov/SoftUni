using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string input = Console.ReadLine();
            int max = int.MinValue;
            while (input != "Stop") {
                max = int.Parse(input) > max ? int.Parse(input) : max;
                input = Console.ReadLine();
            }
            Console.WriteLine(max);
        }
    }
}