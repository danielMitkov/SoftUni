using System;
using System.Linq;
using System.Collections.Generic;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int caffeine = 0;
            Stack<int> milligrams = new Stack<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> drinks = new Queue<int>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            while(milligrams.Any() && drinks.Any())
            {
                int currentMilligrams = milligrams.Pop();
                int currentDrink = drinks.Dequeue();
                int multyply = currentDrink * currentMilligrams;
                if(multyply + caffeine <= 300)
                {
                    caffeine += multyply;
                }
                else
                {
                    drinks.Enqueue(currentDrink);
                    caffeine = caffeine <= 30 ? 0 : caffeine - 30;
                }
            }
            if(drinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ",drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {caffeine} mg caffeine.");
        }
    }
}
