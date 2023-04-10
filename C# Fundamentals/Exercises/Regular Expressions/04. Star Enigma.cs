using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        var regex = @"([^@:!\->]*)@(?<name>[A-Za-z]+)([^@:!\->]*):(?<popul>[0-9]+)([^@:!\->]*)!(?<type>[AD])!([^@:!\->]*)->(?<count>[0-9]+)([^@:!\->]*)";
        var dmg = new List<string>();
        var dead = new List<string>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; n--) {
            var str = Console.ReadLine();
            int key = str.Count(x => "starSTAR".Contains(x));
            var reduced = "";
            for (int i = 0; i < str.Length; i++) reduced += (char)(str[i] - key);
            str = reduced;
            if (Regex.IsMatch(str, regex)) {
                var match = Regex.Match(str, regex);
                if (match.Groups["type"].Value == "A") dmg.Add(match.Groups["name"].Value);
                else dead.Add(match.Groups["name"].Value);
            }
        }
        Console.WriteLine($"Attacked planets: {dmg.Count}");
        foreach (var m in dmg.OrderBy(x => x)) Console.WriteLine($"-> {m}");
        Console.WriteLine($"Destroyed planets: {dead.Count}");
        foreach (var m in dead.OrderBy(x => x)) Console.WriteLine($"-> {m}");
    }
}