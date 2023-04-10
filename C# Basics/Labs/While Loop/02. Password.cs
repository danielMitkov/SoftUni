using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string name = Console.ReadLine();
            string pass = Console.ReadLine();
            string text = Console.ReadLine();
            while (text != pass) {
                text = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}