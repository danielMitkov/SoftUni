using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double hrizantemi = double.Parse(Console.ReadLine());
            double rozi = double.Parse(Console.ReadLine());
            double laleta = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            bool isHoliday = Console.ReadLine() == "Y" ? true : false;
            bool has5 = false;
            bool has10 = false;
            bool has20 = hrizantemi + rozi + laleta > 20 ? true : false;
            switch (season) {
                case "Spring":
                case "Summer":
                    if (laleta > 7 && season == "Spring") {
                        has5 = true;
                    }
                    hrizantemi *= 2;
                    rozi *= 4.1;
                    laleta *= 2.5;
                    break;
                case "Autumn":
                case "Winter":
                    if (rozi >= 10 && season == "Winter") {
                        has10 = true;
                    }
                    hrizantemi *= 3.75;
                    rozi *= 4.5;
                    laleta *= 4.15;
                    break;
            }
            double sum = hrizantemi + rozi + laleta;
            if (isHoliday) {
                sum += sum * 0.15;
            }
            if (has5) {
                sum -= sum * 0.05;
            }
            if (has10) {
                sum -= sum * 0.1;
            }
            if (has20) {
                sum -= sum * 0.2;
            }
            sum += 2;
            Console.WriteLine($"{sum:f2}");
        }
    }
}