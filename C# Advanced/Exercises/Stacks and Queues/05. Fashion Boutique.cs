using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var stk = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
        int capacity = int.Parse(Console.ReadLine());
        int racks = 0;
        while (stk.Any())
        {
            int sum = 0;
            while (stk.Any() && sum + stk.Peek() <= capacity) sum += stk.Pop();
			racks++;
        }
        Console.WriteLine(racks);
    }
}