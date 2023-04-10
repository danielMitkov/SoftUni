using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        string regex = @">>(?<name>[A-Za-z\s]+)<<(?<cost>\d+(\.\d+)?)!(?<count>\d+)";
        var names = new List<string>();
        double total = 0.0;
        string input = "";
        while ((input = Console.ReadLine()) != "Purchase") {
            Match match = Regex.Match(input, regex, RegexOptions.IgnoreCase);
            if (match.Success) {
                names.Add(match.Groups["name"].Value);
                var cost = double.Parse(match.Groups["cost"].Value);
                var count = int.Parse(match.Groups["count"].Value);
                total += cost * count;
            }
        }
        Console.WriteLine($"Bought furniture:");
        if (names.Count > 0) Console.WriteLine($"{string.Join('\n', names)}");
        Console.WriteLine($"Total money spend: {total:F2}");
    }
}