using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var vars = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = vars[0];
        int s = vars[1];
        int x = vars[2];
        var stk = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        while (s > 0)
        {
            stk.Pop();
            s--;
        }
        if (stk.Count == 0)
        {
            Console.WriteLine(0);
            return;
        }
        if (stk.Contains(x)) 
        {
            Console.WriteLine("true");
            return;
        }
        Console.WriteLine(stk.Min());
    }
}