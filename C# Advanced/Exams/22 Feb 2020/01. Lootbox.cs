namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> fBox = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> sBox = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int value = 0;
            while(fBox.Any() && sBox.Any())
            {
                int fItem = fBox.Peek();
                int sItem = sBox.Peek();
                int sum = fItem + sItem;
                if(sum % 2 == 0)
                {
                    value += sum;
                    fBox.Dequeue();
                    sBox.Pop();
                }
                else
                {
                    sBox.Pop();
                    fBox.Enqueue(sItem);
                }
            }
            if(!fBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if(!sBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if(value >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {value}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {value}");
            }
        }
    }
}
