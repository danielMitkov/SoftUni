using System;
using System.Linq;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        int k = int.Parse(Console.ReadLine());
        var s = "";
        while ((s = Console.ReadLine()) != "end") {
            var m = Regex.Match(new string(s.Select(x => (char)(x - k)).ToArray()), "@([A-Za-z]+)[^-@!:>]*!(G|N)!");
            if (m.Success && m.Groups[2].Value == "G") Console.WriteLine(m.Groups[1]);
        }
    }
}