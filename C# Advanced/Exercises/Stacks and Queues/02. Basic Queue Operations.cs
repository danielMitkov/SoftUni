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
        var qu = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        while (s > 0)
        {
            qu.Dequeue();
            s--;
        }
        if (qu.Count == 0)
        {
            Console.WriteLine(0);
            return;
        }
        if (qu.Contains(x)) 
        {
            Console.WriteLine("true");
            return;
        }
        Console.WriteLine(qu.Min());
    }
}