using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Stack<int> ingredients = new Stack<int>(Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Dictionary<string,int> types = new Dictionary<string,int>()
            {
                {"Bread", 25},
                {"Cake",50 },
                {"Pastry", 75},
                {"Fruit Pie", 100}
            };
        Dictionary<string,int> made = new Dictionary<string,int>()
            {
                {"Bread", 0},
                {"Cake",0 },
                {"Pastry", 0},
                {"Fruit Pie", 0}
            };
        while(liquids.Any() && ingredients.Any())
        {
            int liquid = liquids.Peek();
            int ingredient = ingredients.Peek();
            int sum = liquid + ingredient;
            var kvp = types.FirstOrDefault(x => x.Value == sum);
            if(kvp.Key != null)
            {
                made[kvp.Key]++;
                liquids.Dequeue();
                ingredients.Pop();
            }
            else
            {
                liquids.Dequeue();
                ingredient += 3;
                ingredients.Pop();
                ingredients.Push(ingredient);
            }
        }
        if(made.All(x => x.Value > 0))
        {
            Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
        }
        else
        {
            Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
        }
        if(!liquids.Any())
        {
            Console.WriteLine("Liquids left: none");
        }
        else
        {
            Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
        }
        if(!ingredients.Any())
        {
            Console.WriteLine("Ingredients left: none");
        }
        else
        {
            Console.WriteLine($"Ingredients left: {string.Join(", ",ingredients)}");
        }
        foreach(var (type, amount) in made.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{type}: {amount}");
        }
    }
}
