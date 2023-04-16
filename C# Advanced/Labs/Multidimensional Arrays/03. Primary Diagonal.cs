using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var jag = new int[n][];
        for (int row = 0; row < jag.Length; ++row) jag[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = 0;
        for (int i = 0; i < n; ++i) sum += jag[i][i];
        Console.WriteLine(sum);
    }
}