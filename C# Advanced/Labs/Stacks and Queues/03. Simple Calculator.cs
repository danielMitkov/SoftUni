using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var math = Console.ReadLine().Split();
        int result = 0;
        char sign = '+';
        for (int i = 0; i < math.Length; ++i)
        {
            if (math[i] != "+" && math[i] != "-")
            {
                if (sign == '+') result += int.Parse(math[i]);
                if (sign == '-') result -= int.Parse(math[i]);
            }
            if (math[i] == "+") sign = '+';
            if (math[i] == "-") sign = '-';
        }
        Console.WriteLine(result);
    }
}