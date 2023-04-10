using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double priceStudio = 0;
            double priceApartment = 0;
            switch (month) {
                case "May":
                case "October":
                    priceStudio = nights * 50.0;
                    priceApartment = nights * 65.0;
                    if (nights > 7 && nights <= 14) {
                        priceStudio -= priceStudio * 0.05;
                    } else if (nights > 14) {
                        priceStudio -= priceStudio * 0.30;
                    }
                    break;
                case "June":
                case "September":
                    priceStudio = nights * 75.20;
                    priceApartment = nights * 68.70;
                    if (nights > 14) {
                        priceStudio -= priceStudio * 0.20;
                    }
                    break;
                case "July":
                case "August":
                    priceStudio = nights * 76.0;
                    priceApartment = nights * 77.0;
                    break;
            }
            if (nights > 14) {
                priceApartment -= priceApartment * 0.10;
            }
            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        }
    }
}