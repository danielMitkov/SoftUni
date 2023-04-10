using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        var dict = Console.ReadLine().Split(", ").ToDictionary(x => x, y => 0);
        string text = string.Empty;
        while ((text = Console.ReadLine()) != "end of race") {
            string name = string.Join("", Regex.Matches(text, "[A-Za-z]"));
            if (!dict.Any(x => x.Key == name)) continue;
            dict[name] += Regex.Matches(text, "[0-9]").Sum(x => int.Parse(x.Value));
        }
        var list = dict.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
        Console.WriteLine($"1st place: {list[0]}");
        Console.WriteLine($"2nd place: {list[1]}");
        Console.WriteLine($"3rd place: {list[2]}");
    }
}