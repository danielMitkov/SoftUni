using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        var qu = new Queue<string>();
        var text = "";
        while ((text = Console.ReadLine()) != "End")
        {
            if (text != "Paid") qu.Enqueue(text);
            else while (qu.Count > 0) Console.WriteLine(qu.Dequeue());
        }
        Console.WriteLine($"{qu.Count} people remaining.");
    }
}