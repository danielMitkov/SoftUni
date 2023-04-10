using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string city = Console.ReadLine();
            string packet = Console.ReadLine();
            double price = 0;
            switch (city) {
                case "Bansko":
                case "Borovets":
                    if (packet == "withBreakfast" || packet == "noBreakfast") {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    price = GetPrice(packet);
                    break;
                case "Varna":
                case "Burgas":
                    if (packet == "withEquipment" || packet == "noEquipment") {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    price = GetPrice(packet);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    return;
            }
            if (price == -99999) {
                Console.WriteLine("Invalid input!");
                return;
            }
            double days = double.Parse(Console.ReadLine());
            if (days < 1) {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            if (days > 7) {
                days--;
            }
            Console.WriteLine($"The price is {price * days:f2}lv! Have a nice time!");

        }
        static double GetPrice(string choice) {
            bool isVip = Console.ReadLine() == "yes" ? true : false;
            switch (choice) {
                case "withEquipment":
                    if (isVip) {
                        return 90;
                    }
                    return 100;
                case "noEquipment":
                    if (isVip) {
                        return 76;
                    }
                    return 80;
                case "withBreakfast":
                    if (isVip) {
                        return 114.4;
                    }
                    return 130;
                case "noBreakfast":
                    if (isVip) {
                        return 93;
                    }
                    return 100;
                default:
                    return -99999;
            }
        }
    }
}