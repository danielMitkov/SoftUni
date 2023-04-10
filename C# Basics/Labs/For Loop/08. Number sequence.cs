using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
                int current = int.Parse(Console.ReadLine());
                min = current < min ? current : min;
                max = current > max ? current : max;
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}