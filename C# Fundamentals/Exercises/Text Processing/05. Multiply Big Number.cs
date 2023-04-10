using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var numBigStr = Console.ReadLine();
        numBigStr = numBigStr.TrimStart('0');
        char[] numBig = numBigStr.ToCharArray();
        int numSmall = int.Parse(Console.ReadLine());
        if (numSmall == 0) {
            Console.WriteLine("0");
            return;
        }
        var newNum = new List<string>();
        int parse = 0;
        for (int i = numBig.Length - 1; i >= 0; i--) {
            parse = (int.Parse(Convert.ToString(numBig[i])) * numSmall) + parse;
            newNum.Insert(0, (parse % 10).ToString());
            parse /= 10;
        }
        if (parse > 0) Console.WriteLine($"{parse}{string.Join("", newNum)}");
        else Console.WriteLine($"{string.Join("", newNum)}");
    }
}