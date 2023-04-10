using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int age = int.Parse(Console.ReadLine());
            double priceWasher = double.Parse(Console.ReadLine());
            double priceToy = double.Parse(Console.ReadLine());
            double money = 0;
            double increase = 0;
            double countToy = 0;
            double left = 0;
            for (int i = 1; i <= age; ++i) {
                if (i % 2 == 0) {
                    increase += 10;
                    money += increase - 1;
                } else {
                    countToy += 1;
                }
            }
            money += priceToy * countToy;
            left = Math.Abs(money - priceWasher);
            if (money >= priceWasher) {
                Console.WriteLine($"Yes! {left:F2}");
            } else {
                Console.WriteLine($"No! {left:F2}");
            }
        }
    }
}