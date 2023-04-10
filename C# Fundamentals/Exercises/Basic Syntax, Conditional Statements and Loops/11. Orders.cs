using System;
public class Program
{
    public static void Main()
    {
        double totalCost = 0;
        for(int n = int.Parse(Console.ReadLine());n > 0;--n)
        {
            double pricePerCapsule = double.Parse(Console.ReadLine());
            int daysInMonth = int.Parse(Console.ReadLine());
            int capsulesCount = int.Parse(Console.ReadLine());
            double cost = daysInMonth * capsulesCount * pricePerCapsule;
            Console.WriteLine($"The price for the coffee is: ${cost:F2}");
            totalCost += cost;
        }
        Console.WriteLine($"Total: ${totalCost:F2}");
    }
}