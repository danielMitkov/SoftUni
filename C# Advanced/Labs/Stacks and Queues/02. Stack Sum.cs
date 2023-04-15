using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        var input = "";
        while ((input = Console.ReadLine().ToLower()) != "end")
        {
            var args = input.Split();
            if (args[0] == "add")
            {
                stack.Push(int.Parse(args[1]));
                stack.Push(int.Parse(args[2]));
            }
            if (args[0] == "remove")
            {
                if (int.Parse(args[1]) > stack.Count) continue;
                for (int i = 0; i < int.Parse(args[1]); i++) stack.Pop();
            }
        }
        Console.WriteLine($"Sum: {stack.Sum()}");
    }
}