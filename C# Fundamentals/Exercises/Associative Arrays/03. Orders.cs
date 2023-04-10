using System;
using System.Collections.Generic;
using System.Linq;
class Program {
    static void Main() {
        var cost = new Dictionary<string, decimal>();
        var count = new Dictionary<string, decimal>();
        while (true) {
            string line = Console.ReadLine() ?? "buy";
            if (line == "buy") break;
            var data = line.Split(' ');
            if (count.ContainsKey(data[0]))
                count[data[0]] += decimal.Parse(data[2]);
            else count[data[0]] = decimal.Parse(data[2]);
            cost[data[0]] = decimal.Parse(data[1]);
        }
        foreach (var kvp in cost) {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value * count[kvp.Key]:f2}");
        }
    }
}