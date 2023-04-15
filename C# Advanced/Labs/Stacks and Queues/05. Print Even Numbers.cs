using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(string.Join(", ", list.Where(x => x % 2 == 0)));
    }
}