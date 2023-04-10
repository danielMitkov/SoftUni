using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int v = int.Parse(Console.ReadLine());
            double p1 = double.Parse(Console.ReadLine());
            double p2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            p1 = p1 * h;
            p2 = p2 * h;
            if ((p1 + p2) > v) {
                Console.WriteLine($"For {h:f2} hours the pool overflows with {((p1 + p2) - v):f2} liters.");
            } else {
                double p11 = p1 / (p1 + p2) * 100;
                double p22 = p2 / (p1 + p2) * 100;
                Console.WriteLine($"The pool is {((p1 + p2) / v * 100):f2}% full. Pipe 1: {p11:f2}%. Pipe 2: {p22:f2}%.");
            }
        }
    }
}