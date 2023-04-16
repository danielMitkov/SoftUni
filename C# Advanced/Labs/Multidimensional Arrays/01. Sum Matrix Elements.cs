using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        var jag = new int[size[0]][];
        for (int row = 0; row < jag.Length; ++row) jag[row] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        Console.WriteLine(jag.Length);
        Console.WriteLine(jag[0].Length);
        int sum = 0;
        foreach (var arr in jag) sum += arr.Sum();
        Console.WriteLine(sum);
    }
}