using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var qu = new Queue<string>(Console.ReadLine().Split());
        int n = int.Parse(Console.ReadLine());
        int passes = 0;
        while (qu.Count > 1)
        {
            var temp = qu.Dequeue();
            passes++;
            if (passes != n) qu.Enqueue(temp);
            else {
                passes = 0;
                Console.WriteLine($"Removed {temp}");
            }
        }
        Console.WriteLine($"Last is {qu.Dequeue()}");
    }
}