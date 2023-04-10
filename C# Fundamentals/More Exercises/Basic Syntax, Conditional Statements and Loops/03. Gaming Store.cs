using System;
public class Program
{
    public static void Main()
    {
        double money = double.Parse(Console.ReadLine());
        double moneyBackUp = money;
        string input = string.Empty;
        while((input = Console.ReadLine()) != "Game Time")
        {
            switch(input)
            {
                case "OutFall 4":
                    money = TryBuy(money,"OutFall 4",39.99);
                    break;
                case "CS: OG":
                    money = TryBuy(money,"CS: OG",15.99);
                    break;
                case "Zplinter Zell":
                    money = TryBuy(money,"Zplinter Zell",19.99);
                    break;
                case "Honored 2":
                    money = TryBuy(money,"Honored 2",59.99);
                    break;
                case "RoverWatch":
                    money = TryBuy(money,"RoverWatch",29.99);
                    break;
                case "RoverWatch Origins Edition":
                    money = TryBuy(money,"RoverWatch Origins Edition",39.99);
                    break;
                default:
                    Console.WriteLine("Not Found");
                    break;
            }
            if(money <= 0)
            {
                Console.WriteLine("Out of money!");
                return;
            }
        }
        Console.WriteLine($"Total spent: ${moneyBackUp - money:F2}. Remaining: ${money:F2}");
    }
    public static double TryBuy(double money,string game,double cost)
    {
        if(money >= cost)
        {
            money -= cost;
            Console.WriteLine($"Bought {game}");
        }
        else
        {
            Console.WriteLine("Too Expensive");
        }
        return money;
    }
}