using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string size = Console.ReadLine();
            string color = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            int price = 0;
            switch (size) {
                case "Large":
                    price = getPrice(color, 16, 12, 9);
                    break;
                case "Medium":
                    price = getPrice(color, 13, 9, 7);
                    break;
                case "Small":
                    price = getPrice(color, 9, 8, 5);
                    break;
            }
            double total = price * count;
            total -= total * 0.35;
            Console.WriteLine($"{total:f2} leva.");
        }
        static int getPrice(string date, int first, int second, int third) {
            if (date == "Red") {
                return first;
            }
            if (date == "Green") {
                return second;
            }
            if (date == "Yellow") {
                return third;
            }
            return 0;
        }
    }
}