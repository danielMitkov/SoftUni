using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var openIndexes = new Stack<int>();
        var math = Console.ReadLine();
        for (int iClosed = 0; iClosed < math.Length; iClosed++)
        {
            if (math[iClosed] == '(') openIndexes.Push(iClosed);
            if (math[iClosed] == ')')
            {
                for (int iOpen = openIndexes.Pop(); iOpen <= iClosed; iOpen++) Console.Write(math[iOpen]);
                Console.WriteLine();
            }
        }
    }
}