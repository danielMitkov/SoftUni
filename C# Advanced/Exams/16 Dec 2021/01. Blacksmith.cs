using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> steals = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbons = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string,int> types = new Dictionary<string,int>()
            {
                {"Gladius", 70},
                {"Shamshir",80 },
                {"Katana", 90},
                {"Sabre", 110},
                {"Broadsword",150 }
            };
            Dictionary<string,int> made = new Dictionary<string,int>()
            {
                {"Gladius", 0},
                {"Shamshir",0 },
                {"Katana", 0},
                {"Sabre", 0},
                {"Broadsword",0 }
            };
            while(steals.Any() && carbons.Any())
            {
                int steal = steals.Peek();
                int carbon = carbons.Peek();
                int sum = steal + carbon;
                var kvp = types.FirstOrDefault(x=>x.Value == sum);
                if(kvp.Key != null)
                {
                    made[kvp.Key]++;
                    steals.Dequeue();
                    carbons.Pop();
                }
                else
                {
                    steals.Dequeue();
                    carbon += 5;
                    carbons.Pop();
                    carbons.Push(carbon);
                }
            }
            if(made.Values.Any(x=>x>0))
            {
                Console.WriteLine($"You have forged {made.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if(!steals.Any())
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steals)}");
            }
            if(!carbons.Any())
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbons)}");
            }
            foreach(var (type,amount) in made.Where(x=>x.Value > 0).OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{type}: {amount}");
            }
        }
    }
}
