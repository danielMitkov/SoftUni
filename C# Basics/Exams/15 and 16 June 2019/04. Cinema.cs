using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double c = double.Parse(Console.ReadLine());
            double a = 0;
            while (true) {
                string text = Console.ReadLine();
                if (text == "Movie time!") {
                    Console.WriteLine($"There are {c} seats left in the cinema.");
                    break;
                }
                double h = double.Parse(text);
                if (h > c) {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                c -= h;
                double b = h * 5;
                if (h % 3 == 0) {
                    b -= 5;
                }
                a += b;
            }
            Console.WriteLine($"Cinema income - {a} lv.");
        }
    }
}