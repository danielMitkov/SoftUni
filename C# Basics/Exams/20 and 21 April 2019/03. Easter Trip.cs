using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string country = Console.ReadLine();
            string date = Console.ReadLine();
            double nights = double.Parse(Console.ReadLine());
            int price = 0;
            switch (country) {
                case "France":
                    price = getPrice(date, 30, 35, 40);
                    break;
                case "Italy":
                    price = getPrice(date, 28, 32, 39);
                    break;
                case "Germany":
                    price = getPrice(date, 32, 37, 43);
                    break;
            }
            Console.WriteLine($"Easter trip to {country} : {nights * price:F2} leva.");
        }
        static int getPrice(string date, int first, int second, int third) {
            if (date == "21-23") {
                return first;
            }
            if (date == "24-27") {
                return second;
            }
            if (date == "28-31") {
                return third;
            }
            return 0;
        }
    }
}