using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string film = Console.ReadLine();
            string hall = Console.ReadLine();
            double tickets = double.Parse(Console.ReadLine());
            double price = 0;
            switch (film) {
                case "A Star Is Born":
                    price = GetPrice(hall, 7.5, 10.5, 13.5);
                    break;
                case "Bohemian Rhapsody":
                    price = GetPrice(hall, 7.35, 9.45, 12.75);
                    break;
                case "Green Book":
                    price = GetPrice(hall, 8.15, 10.25, 13.25);
                    break;
                case "The Favourite":
                    price = GetPrice(hall, 8.75, 11.55, 13.95);
                    break;
            }
            Console.WriteLine($"{film} -> {tickets * price:f2} lv.");
        }
        static double GetPrice(string choice ,double normal, double luxury, double ultra) {
            switch (choice) {
                case "normal":
                    return normal;
                case "luxury":
                    return luxury;
                case "ultra luxury":
                    return ultra;
            }
            return 0;
        }
    }
}