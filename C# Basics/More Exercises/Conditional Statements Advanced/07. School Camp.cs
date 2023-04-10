using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string season = Console.ReadLine();
            string type = Console.ReadLine();
            double students = double.Parse(Console.ReadLine());
            double nights = double.Parse(Console.ReadLine());
            string sport = "";
            bool has5 = false;
            bool has15 = false;
            bool has50 = false;
            double price = 0;
            if (students >= 50) {
                has50 = true;
            }
            if (students >= 20 && students < 50) {
                has15 = true;
            }
            if (students >= 10 && students < 20) {
                has5 = true;
            }
            switch (type) {
                case "boys":
                    if (season == "Winter") {
                        price = students * 9.6 * nights;
                        sport = "Judo";
                    }
                    if (season == "Spring") {
                        price = students * 7.2 * nights;
                        sport = "Tennis";
                    }
                    if (season == "Summer") {
                        price = students * 15 * nights;
                        sport = "Football";
                    }
                    break;
                case "girls":
                    if(season == "Winter") {
                        price = students * 9.6 * nights;
                        sport = "Gymnastics";
                    }
                    if (season == "Spring") {
                        price = students * 7.2 * nights;
                        sport = "Athletics";
                    }
                    if (season == "Summer") {
                        price = students * 15 * nights;
                        sport = "Volleyball";
                    }
                    break;
                case "mixed":
                    if (season == "Winter") {
                        price = students * 10 * nights;
                        sport = "Ski";
                    }
                    if (season == "Spring") {
                        price = students * 9.5 * nights;
                        sport = "Cycling";
                    }
                    if (season == "Summer") {
                        price = students * 20 * nights;
                        sport = "Swimming";
                    }
                    break;
            }
            if (has5) {
                price -= price * 0.05;
            }
            if (has15) {
                price -= price * 0.15;
            }
            if (has50) {
                price -= price * 0.5;
            }
            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}