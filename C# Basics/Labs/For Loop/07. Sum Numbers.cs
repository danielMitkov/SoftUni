using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int sum = 0;
            for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
                sum += int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}