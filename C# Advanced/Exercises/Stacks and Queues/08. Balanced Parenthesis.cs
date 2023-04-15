using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var str = Console.ReadLine();
        if (str.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }
        var opens = new Stack<char>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '(' || str[i] == '{' || str[i] == '[') opens.Push(str[i]);
            if (str[i] == ')' && opens.Peek() == '(') opens.Pop();
            if (str[i] == '}' && opens.Peek() == '{') opens.Pop();
            if (str[i] == ']' && opens.Peek() == '[') opens.Pop();
        }
        if (!opens.Any()) Console.WriteLine("YES");
        else Console.WriteLine("NO");
    }
}