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
        for (int row = 0; row < jag.Length; ++row) jag[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int col = 0; col < size[1]; ++col)
        {
            int sum = 0;
            for (int row = 0; row < size[0]; ++row) sum += jag[row][col];
            Console.WriteLine(sum);
        }
    }
}