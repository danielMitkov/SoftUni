using System;
public class Program
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        double headsetCost = double.Parse(Console.ReadLine());
        double mouseCost = double.Parse(Console.ReadLine());
        double keyboardCost = double.Parse(Console.ReadLine());
        double displayCost = double.Parse(Console.ReadLine());
        int headsetTimer = 2;
        int mouseTimer = 3;
        int displayTimer = 2;
        double costs = 0;
        for(int n = count;n > 0;--n)
        {
            headsetTimer--;
            mouseTimer--;
            if(headsetTimer == 0 && mouseTimer == 0)
            {
                costs += keyboardCost;
                displayTimer--;
            }
            if(displayTimer == 0)
            {
                costs += displayCost;
                displayTimer = 2;
            }
            if(headsetTimer == 0)
            {
                costs += headsetCost;
                headsetTimer = 2;
            }
            if(mouseTimer == 0)
            {
                costs += mouseCost;
                mouseTimer = 3;
            }
        }
        Console.Write($"Rage expenses: {costs:F2} lv.");
    }
}