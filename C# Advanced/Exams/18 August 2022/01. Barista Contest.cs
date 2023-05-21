using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffees = new Queue<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milks = new Stack<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string,int> types = new Dictionary<string,int>()
            {
                {"Cortado",50 },
                {"Espresso",75 },
                {"Capuccino",100 },
                {"Americano",150 },
                {"Latte",200 }
            };
            Dictionary<string,int> made = new Dictionary<string,int>()
            {
                {"Cortado",0 },
                {"Espresso",0 },
                {"Capuccino",0 },
                {"Americano",0 },
                {"Latte",0 }
            };
            while(coffees.Any() && milks.Any())
            {
                int coffee = coffees.Peek();
                int milk = milks.Peek();
                int sum = coffee + milk;
                var kvp = types.FirstOrDefault(x => x.Value == sum);
                if(kvp.Key != null)
                {
                    coffees.Dequeue();
                    milks.Pop();
                    made[kvp.Key]++;
                }
                else
                {
                    coffees.Dequeue();
                    milks.Push(milks.Pop() - 5);
                }
            }
            if(!coffees.Any() && !milks.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            if(!coffees.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",coffees)}");
            }
            if(!milks.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ",milks)}");
            }
            foreach(var (type, count) in made.Where(x => x.Value > 0).OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{type}: {count}");
            }
        }
    }
}
