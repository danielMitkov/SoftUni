using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    static void Main(string[] args)
    {
        var data = Console.ReadLine()!.Split(' ');
        var counts = new Dictionary<char,int>();
        foreach(var word in data)
        {
            var chars = word.ToCharArray();
            foreach(char c in chars)
            {
                if(counts.ContainsKey(c)) counts[c]++;
                else counts.Add(c,1);
            }

        }
        Console.Write(String.Join('\n',counts.Select(x => $"{x.Key} -> {x.Value}")));
    }
}