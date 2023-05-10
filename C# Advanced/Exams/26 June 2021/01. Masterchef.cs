namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> baskets = new Queue<int>(Console.ReadLine()
                            .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> levels = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string,int> types = new Dictionary<string,int>()
            {
                {"Dipping sauce", 150},
                {"Green salad",250 },
                {"Chocolate cake", 300},
                {"Lobster", 400},
            };
            Dictionary<string,int> made = new Dictionary<string,int>()
            {
                {"Dipping sauce", 0},
                {"Green salad",0 },
                {"Chocolate cake", 0},
                {"Lobster", 0},
            };
            while(baskets.Any() && levels.Any())
            {
                int basket = baskets.Peek();
                int level = levels.Peek();
                if(basket == 0)
                {
                    baskets.Dequeue();
                    continue;
                }
                int multiple = basket * level;
                var kvp = types.FirstOrDefault(x => x.Value == multiple);
                if(kvp.Key != null)
                {
                    made[kvp.Key]++;
                    baskets.Dequeue();
                    levels.Pop();
                }
                else
                {
                    levels.Pop();
                    basket += 5;
                    baskets.Dequeue();
                    baskets.Enqueue(basket);
                }
            }
            if(made["Dipping sauce"] >= 1 && made["Green salad"] >= 1 && made["Chocolate cake"] >= 1 && made["Lobster"] >= 1)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if(baskets.Any())
            {
                Console.WriteLine($"Ingredients left: {baskets.Sum()}");
            }
            foreach(var (type, amount) in made.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {type} --> {amount}");
            }
        }
    }
}
