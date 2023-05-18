using System;
using System.Collections.Generic;
using System.Linq;
namespace Program31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var waters = new Queue<double>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            var flours = new Stack<double>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            var ratios = new Dictionary<string,(int pWater, int pFlour)>()
            {
                { "Croissant", (50,50) },
                { "Muffin", (40,60) },
                { "Baguette", (30,70) },
                { "Bagel", (20,80) }
            };
            var counts = new Dictionary<string,int>()
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };
            while(waters.Any() && flours.Any())
            {
                double water = waters.Peek();
                double flour = flours.Peek();
                double sum = water + flour;
                double rWater = water * 100 / sum;
                double rFlour = flour * 100 / sum;
                var kvp = ratios.FirstOrDefault(x => x.Value.pWater == rWater && x.Value.pFlour == rFlour);
                if(kvp.Key != null)
                {
                    counts[kvp.Key]++;
                    waters.Dequeue();
                    flours.Pop();
                }
                else
                {
                    waters.Dequeue();
                    flours.Pop();
                    flour -= water;
                    counts["Croissant"]++;
                    flours.Push(flour);
                }
            }
            foreach(var (food, count) in counts.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{food}: {count}");
            }
            if(!waters.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ",waters)}");
            }
            if(!flours.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ",flours)}");
            }
        }
    }
}
