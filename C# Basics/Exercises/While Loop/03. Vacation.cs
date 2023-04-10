using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double neededMoney = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            int dayCount = 0;
            int dayTemp = 0;
            while (dayTemp < 5) {
                string action = Console.ReadLine();
                double amount = double.Parse(Console.ReadLine());
                dayCount++;
                if (action == "save") {
                    dayTemp = 0;
                    money += amount;
                    if (money >= neededMoney) {
                        Console.WriteLine($"You saved the money for {dayCount} days.");
                        return;
                    }
                }
                if (action == "spend") {
                    dayTemp++;
                    money -= amount;
                    if (money < 0) {
                        money = 0;
                    }
                }
            }
            Console.WriteLine("You can't save the money.");
            Console.WriteLine(dayCount);
        }
    }
}