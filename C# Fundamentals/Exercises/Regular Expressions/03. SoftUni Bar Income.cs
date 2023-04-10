using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        var regex = @"(.+)?%(?<name>[A-Z][a-z]+)%(.+)?<(?<item>\w+)>(.+)?\|(?<count>\d+)\|(\D+)?(?<cost>\d+(\.\d+)?)\$(.+)?";
        decimal sum = 0;
        var str = "";
        while ((str = Console.ReadLine()) != "end of shift") {
            Match data = Regex.Match(str, regex);
            if (!data.Success) continue;
            string name = data.Groups["name"].Value;
            string item = data.Groups["item"].Value;
            int count = int.Parse(data.Groups["count"].Value);
            decimal cost = decimal.Parse(data.Groups["cost"].Value);
            Console.WriteLine($"{name}: {item} - {cost * count:f2}");
            sum += cost * count;
        }
        Console.WriteLine($"Total income: {sum:f2}");
    }
}