using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        Stack<int> whites = new(Console.ReadLine().Split().Select(int.Parse));
        Queue<int> greys = new(Console.ReadLine().Split().Select(int.Parse));
        Dictionary<string,int> locations = new()
        {
            {"Sink",40},
            {"Oven",50},
            {"Countertop",60},
            {"Wall",70},
            { "Floor",-1}
        };
        Dictionary<string,int> counts = new()
        {
            {"Sink",0},
            {"Oven",0},
            {"Countertop",0},
            {"Wall",0},
            { "Floor",0}
        };
        while(whites.Any() && greys.Any())
        {
            var white = whites.Pop();
            var grey = greys.Dequeue();
            if(white == grey)
            {
                int larger = white + grey;
                var kvp = locations.FirstOrDefault(x => x.Value == larger);
                if(kvp.Key != null)
                {
                    counts[kvp.Key]++;
                }
                else
                {
                    counts["Floor"]++;
                }
            }
            else
            {
                whites.Push(white / 2);
                greys.Enqueue(grey);
            }
        }
        Console.Write("White tiles left: ");
        if(!whites.Any())
        {
            Console.WriteLine("none");
        }
        else
        {
            Console.WriteLine(string.Join(", ",whites));
        }
        Console.Write("Grey tiles left: ");
        if(!greys.Any())
        {
            Console.WriteLine("none");
        }
        else
        {
            Console.WriteLine(string.Join(", ",greys));
        }
        Dictionary<string,int> toPrint = new(counts.Where(x => x.Value > 0));
        foreach(var (place, count) in toPrint.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{place}: {count}");
        }
    }
}
