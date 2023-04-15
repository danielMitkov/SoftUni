using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Stack<string> stk = new(new[] { "" });
        for (int n = int.Parse(Console.ReadLine()); n > 0; n--)
        {
            var str = Console.ReadLine();
            if (str[0] == '1') stk.Push(stk.Peek() + new string(str.Skip(2).ToArray()));
            if (str[0] == '2') stk.Push(new string(stk.Peek().SkipLast(int.Parse(str.Split()[1])).ToArray()));
            if (str[0] == '3') Console.WriteLine(stk.Peek()[int.Parse(str.Split()[1]) - 1]);
            if (str[0] == '4') stk.Pop();
        }
    }
}