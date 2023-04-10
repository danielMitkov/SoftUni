using System;
public class Program
{
    public static void Main()
    {
        double money = double.Parse(Console.ReadLine());
        int count = int.Parse(Console.ReadLine());
        double saberCost = double.Parse(Console.ReadLine());
        double robeCost = double.Parse(Console.ReadLine());
        double beltCost = double.Parse(Console.ReadLine());
        saberCost *= Math.Ceiling(count + count * 0.1);
        robeCost *= count;
        beltCost *= count - count / 6;
        double cost = saberCost + robeCost + beltCost;
        if(cost <= money)
        {
            Console.WriteLine($"The money is enough - it would cost {cost:F2}lv.");
        }
        else
        {
            Console.WriteLine($"John will need {cost - money:F2}lv more.");
        }
    }
}