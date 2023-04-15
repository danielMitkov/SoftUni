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
        int passed = 0;
        var qu = new Queue<string>();
        var text = "";
        while ((text = Console.ReadLine()) != "end")
        {
            if (text == "green")
            {
                for (int i = 0; i < n && qu.Count > 0; ++i)
                {
                    Console.WriteLine($"{qu.Dequeue()} passed!");
                    passed++;
                }
            }
            else qu.Enqueue(text);
        }
        Console.WriteLine($"{passed} cars passed the crossroads.");
    }
}