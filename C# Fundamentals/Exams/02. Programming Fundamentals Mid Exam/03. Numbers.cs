using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        int[] top = arr.Where(x => x > arr.Average()).OrderByDescending(x => x).Take(5).ToArray();
        if (top.Length > 0) Console.Write(String.Join(" ", top));
        else Console.Write("No");
    }
}