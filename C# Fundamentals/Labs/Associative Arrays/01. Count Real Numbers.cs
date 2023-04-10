using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var data = Console.ReadLine()!.Split(' ').Select(double.Parse);
        var counts = new SortedDictionary<double, int>();
        foreach (var num in data) {
            if (!counts.ContainsKey(num)) {
                counts.Add(num, 1);
            } else {
                counts[num]++;
            }
        }
        foreach (var num in counts) {
            System.Console.WriteLine($"{num.Key} -> {num.Value}");
        }
    }
}