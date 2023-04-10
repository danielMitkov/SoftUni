using System;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        var prt = Console.ReadLine().Split('|');
        var cap = Regex.Match(prt[0], @"([#$%*&])([A-Z]+)(\1)").Groups[2].Value;
        foreach (var c in cap) Console.WriteLine(Regex.Match(' ' + prt[2], $@" ({c}[^ ]{{{Regex.Match(prt[1], (int)c + @":(\d{2})").Groups[1].Value}}})\b"));
    }
}