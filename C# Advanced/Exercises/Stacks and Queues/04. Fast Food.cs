using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        int food = int.Parse(Console.ReadLine());
        var qu = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
        Console.WriteLine(qu.Max());
        while (qu.Count > 0 && food >= qu.Peek()) food -= qu.Dequeue();
        if (qu.Count == 0) Console.WriteLine("Orders complete");
        else Console.WriteLine($"Orders left: {string.Join(" ", qu)}");
    }
}