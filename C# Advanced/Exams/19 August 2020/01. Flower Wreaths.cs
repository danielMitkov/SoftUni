using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var lilies = new Stack<int>(Console.ReadLine()
            .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        var roses = new Queue<int>(Console.ReadLine()
            .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        int wreaths = 0;
        int storedSum = 0;
        while(lilies.Any() && roses.Any())
        {
            int lili = lilies.Pop();
            int rose = roses.Dequeue();
            int sum = lili + rose;
            if(sum > 15)
            {
                while(sum > 15)
                {
                    sum -= 2;
                }
            }
            if(sum == 15)
            {
                wreaths++;
            }
            if(sum < 15)
            {
                storedSum += sum;
            }
        }
        wreaths += storedSum / 15;
        if(wreaths >= 5)
        {
            Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
        }
        else
        {
            Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}
