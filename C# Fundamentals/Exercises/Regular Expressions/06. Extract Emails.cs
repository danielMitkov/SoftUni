using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        string input = Console.ReadLine();
        Regex regexForEmail = new Regex(@"(?<=\s)(?<user>(?![_])[A-za-z0-9]+(?:[\.\-_][A-za-z0-9]+)*)@(?<host>[a-zA-Z]+(?:[\-][a-zA-z]+)*(?:\.[a-zA-Z]+(?:[\-][a-zA-Z]+)*)*\.[a-z]+)");
        MatchCollection matchesEmail = regexForEmail.Matches(input);
        if (regexForEmail.IsMatch(input)) {
            foreach (Match match in matchesEmail) {
                Console.Write(match.Groups["user"]);
                Console.Write("@");
                Console.WriteLine(match.Groups["host"]);
            }
        }
    }
}