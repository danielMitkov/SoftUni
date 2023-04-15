using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var stk = new Stack<int>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n)
        {
            var text = Console.ReadLine();
            if (text[0] == '1') stk.Push(text.Split().Select(int.Parse).ToArray()[1]);
            if (text[0] == '2' && stk.Count > 0) stk.Pop();
            if (text[0] == '3' && stk.Count > 0) Console.WriteLine(stk.Max());
            if (text[0] == '4' && stk.Count > 0) Console.WriteLine(stk.Min());
        }
        Console.WriteLine(string.Join(", ", stk));
    }
}