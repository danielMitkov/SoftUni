using System;
class Program
{
    static void Main()
    {
        double pTrip = double.Parse(Console.ReadLine());
        int puzzels = int.Parse(Console.ReadLine());
        int dolls = int.Parse(Console.ReadLine());
        int bears = int.Parse(Console.ReadLine());
        int minions = int.Parse(Console.ReadLine());
        int trucks = int.Parse(Console.ReadLine());
        double pPuzzels = puzzels * 2.60;
        double pDolls = dolls * 3.0;
        double pBears = bears * 4.10;
        double pMinions = minions * 8.20;
        double pTrucks = trucks * 2.0;
        double income = pPuzzels + pDolls + pBears + pMinions + pTrucks;
        int sumToys = puzzels + dolls + bears + minions + trucks;
        if(sumToys >= 50)
        {
            double discount = income * 0.25;
            income = income - discount;
        }
        double rent = income * 0.1;
        double FinalIncome = income - rent;
        if(FinalIncome >= pTrip)
        {
            double moneyLeft = FinalIncome - pTrip;
            Console.WriteLine($"Yes! {moneyLeft:F2} lv left.");
        }
        else
        {
            double moneyNeeded = pTrip - FinalIncome;
            Console.WriteLine($"Not enough money! {moneyNeeded:F2} lv needed.");
        }
    }
}