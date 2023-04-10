using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            decimal r = 0;
            for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
                r += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(r);
        }
    }
}