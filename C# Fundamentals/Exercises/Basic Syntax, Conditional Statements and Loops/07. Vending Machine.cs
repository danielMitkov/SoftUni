using System;
public class Program
{
    public static void Main()
    {
        double money = 0;
        string input = string.Empty;
        while((input = Console.ReadLine()) != "Start")
        {
            double coin = double.Parse(input);
            if(coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
            {
                money += coin;
            }
            else
            {
                Console.WriteLine($"Cannot accept {coin}");
            }
        }
        while((input = Console.ReadLine()) != "End")
        {
            switch(input)
            {
                case "Nuts":
                    money = Buy(money,"nuts",2);
                    break;
                case "Water":
                    money = Buy(money,"water",0.7);
                    break;
                case "Crisps":
                    money = Buy(money,"crisps",1.5);
                    break;
                case "Soda":
                    money = Buy(money,"soda",0.8);
                    break;
                case "Coke":
                    money = Buy(money,"coke",1);
                    break;
                default:
                    Console.WriteLine("Invalid product");
                    break;
            }
        }
        Console.Write($"Change: {money:F2}");
    }
    public static double Buy(double money,string product,double price)
    {
        if(money >= price)
        {
            money -= price;
            Console.WriteLine($"Purchased {product}");
        }
        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
        return money;
    }
}