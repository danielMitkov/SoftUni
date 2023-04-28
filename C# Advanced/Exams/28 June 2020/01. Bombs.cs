using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

public class Program
{
    public static void Main()
    {
        var effects = new Queue<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        var casings = new List<int>(Console.ReadLine()
            .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Dictionary<string,int> types = new Dictionary<string,int>()
            {
                {"Datura Bombs", 40},
                {"Cherry Bombs",60 },
                {"Smoke Decoy Bombs", 120}
            };
        Dictionary<string,int> made = new Dictionary<string,int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs",0 },
                {"Smoke Decoy Bombs", 0}
            };
        while(effects.Any() && casings.Any())
        {
            int effect = effects.Peek();
            int sum = effect + casings.Last();
            var kvp = types.FirstOrDefault(x => x.Value == sum);
            if(kvp.Key != null)
            {
                made[kvp.Key]++;
                effects.Dequeue();
                casings.RemoveAt(casings.Count-1);
            }
            else
            {
                casings[casings.Count - 1] -= 5;
            }
            if(made["Datura Bombs"] >= 3 && made["Cherry Bombs"] >= 3 && made["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
                break;
            }
        }
        if(made["Datura Bombs"] < 3 || made["Cherry Bombs"] < 3 || made["Smoke Decoy Bombs"] < 3)
        {
            Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
        }
        if(!effects.Any())
        {
            Console.WriteLine("Bomb Effects: empty");
        }
        else
        {
            Console.WriteLine($"Bomb Effects: {string.Join(", ",effects)}");
        }
        if(!casings.Any())
        {
            Console.WriteLine("Bomb Casings: empty");
        }
        else
        {
            Console.WriteLine($"Bomb Casings: {string.Join(", ",casings)}");
        }
        foreach(var (type, amount) in made.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{type}: {amount}");
        }
    }
}
