using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double people = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());
            double bed = double.Parse(Console.ReadLine());
            double umbrela = double.Parse(Console.ReadLine());
            double entrance = people * tax;
            double bedss = (int)Math.Ceiling(people * 0.75);
            bedss = bedss * bed;
            double umbrelas = (int)Math.Ceiling(people * 0.5);
            umbrelas = umbrelas * umbrela;
            Console.WriteLine($"{entrance + bedss + umbrelas:f2} lv.");

        }
    }
}