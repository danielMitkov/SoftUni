using System;
using System.Linq;
class SoftUni {
    static void Main() {
        string[] input = Console.ReadLine().Split('|').Reverse().ToArray();
        string temp = string.Join(" ", input);
        input = temp.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        Console.WriteLine(string.Join(" ", input));
    }
}