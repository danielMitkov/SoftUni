using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        var s = new StringBuilder();
        foreach (Match m in Regex.Matches(Console.ReadLine().ToUpper(), @"([^\d]+)([\d]+)"))
            for (int i = 0; i < int.Parse(m.Groups[2].Value); i++) s.Append(m.Groups[1].Value);
        Console.Write($"Unique symbols used: {s.ToString().Distinct().Count()}\n{s}");
    }
}