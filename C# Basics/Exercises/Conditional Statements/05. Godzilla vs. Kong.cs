using System;
class Program
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        int people = int.Parse(Console.ReadLine());
        double pSuit = double.Parse(Console.ReadLine());
        double pClothes = people * pSuit;
        double decor = 0.1 * budget;
        if(people > 150)
        {
            pClothes = 0.9 * pClothes;
        }
        double expenses = decor + pClothes;
        if(expenses > budget)
        {
            Console.WriteLine("Not enough money!");
            double needMoney = expenses - budget;
            Console.WriteLine($"Wingard needs {needMoney:F2} leva more.");
        }
        else
        {
            Console.WriteLine("Action!");
            double moneyLeft = budget - expenses;
            Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
        }
    }
}