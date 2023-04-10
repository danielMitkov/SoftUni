using System;
public class Program
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        string day = Console.ReadLine();
        double price = 0;
        switch(type)
        {
            case "Students":
                price = GetPrice(day,8.45,9.80,10.46) * count;
                if(count >= 30)
                {
                    price -= price * 0.15;
                }
                break;
            case "Business":
                if(count >= 100)
                {
                    count -= 10;
                }
                price = GetPrice(day,10.90,15.60,16) * count;
                break;
            case "Regular":
                price = GetPrice(day,15,20,22.50) * count;
                if(count >= 10 && count <= 20)
                {
                    price -= price * 0.05;
                }
                break;
        }
        Console.Write($"Total price: {price:F2}");
    }
    public static double GetPrice(string day,params double[] prices)
    {
        switch(day)
        {
            case "Friday":
                return prices[0];
            case "Saturday":
                return prices[1];
            default:
                return prices[2];
        }
    }
}