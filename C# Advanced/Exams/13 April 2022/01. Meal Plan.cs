using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> strings = new Queue<string>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries));
            List<int> list = new List<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string,int> dict = new Dictionary<string,int>()
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 }
            };
            int mealsEaten = 0;
            while(strings.Any() && list.Any())
            {
                string str = strings.Dequeue();
                mealsEaten++;
                list[list.Count - 1] -= dict[str];
                if(list[list.Count - 1] <= 0)
                {
                    int num = Math.Abs(list[list.Count - 1]);
                    list.RemoveAt(list.Count - 1);
                    if(list.Any())
                    {
                        list[list.Count - 1] -= num;
                    }
                }
            }
            if(!strings.Any())
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                list.Reverse();
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ",list)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",strings)}.");
            }
        }
    }
}
