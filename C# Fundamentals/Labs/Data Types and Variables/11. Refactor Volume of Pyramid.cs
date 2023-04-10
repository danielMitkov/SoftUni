using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("Length: ");
            double Lenght = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double Width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double Height = double.Parse(Console.ReadLine());
            double volume = (Lenght * Width * Height) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");
        }
    }
}