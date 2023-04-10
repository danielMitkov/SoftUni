using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double temp = double.Parse(Console.ReadLine());
            if (temp >= 26 && temp <= 35) {
                Console.WriteLine("Hot");
                return;
            }
            if (temp >= 20.1 && temp <= 25.9) {
                Console.WriteLine("Warm");
                return;
            }
            if (temp >= 15 && temp <= 20) {
                Console.WriteLine("Mild");
                return;
            }
            if (temp >= 12 && temp <= 14.9) {
                Console.WriteLine("Cool");
                return;
            }
            if (temp >= 5 && temp <= 11.9) {
                Console.WriteLine("Cold");
                return;
            }
            Console.WriteLine("unknown");
        }
    }
}