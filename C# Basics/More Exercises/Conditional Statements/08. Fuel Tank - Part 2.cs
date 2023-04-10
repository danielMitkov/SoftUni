using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string type = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            bool hasCard = Console.ReadLine() == "Yes" ? true : false;
            bool has20Dis = liters >= 20 && liters <= 25 ? true : false;
            bool has25Dis = liters > 25 ? true : false;
            switch (type) {
                case "Diesel":
                    double discountDie = liters * 0.12;
                    liters *= 2.33;
                    if (hasCard) {
                        liters -= discountDie;
                    }
                    break;
                case "Gasoline":
                    double discountGaso = liters * 0.18;
                    liters *= 2.22;
                    if (hasCard) {
                        liters -= discountGaso;
                    }
                    break;
                case "Gas":
                    double discountGas = liters * 0.08;
                    liters *= 0.93;
                    if (hasCard) {
                        liters -= discountGas;
                    }
                    break;
            }
            if (has20Dis) {
                liters -= liters * 0.08;
            }
            if (has25Dis) {
                liters -= liters * 0.10;
            }
            Console.WriteLine($"{liters:f2} lv.");
        }
    }
}