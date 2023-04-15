using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var que = new Queue<string>(Console.ReadLine().Split(", "));
        while (que.Any())
        {
            var action = Console.ReadLine();
            if (action == "Play") que.Dequeue();
            if (action.StartsWith("Add"))
            {
                var song = action.Substring(4);
                if (que.Contains(song)) Console.WriteLine($"{song} is already contained! ");
                else que.Enqueue(song);
            }
            if (action == "Show") Console.WriteLine(string.Join(", ", que));
        }
        Console.WriteLine("No more songs!");
    }
}