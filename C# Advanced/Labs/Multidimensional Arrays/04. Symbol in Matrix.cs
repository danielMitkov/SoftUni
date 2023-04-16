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
        var jag = new char[n][];
        for (int row = 0; row < jag.Length; ++row) jag[row] = Console.ReadLine().ToCharArray();
        char c = char.Parse(Console.ReadLine());
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (jag[row][col] == c)
                {
                    Console.WriteLine($"({row}, {col})");
                    return;
                }
            }
        }
        Console.WriteLine($"{c} does not occur in the matrix");
    }
}