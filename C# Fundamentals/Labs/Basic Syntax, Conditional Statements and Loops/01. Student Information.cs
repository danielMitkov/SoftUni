using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double bla = double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {bla:f2}");
        }
    }
}