using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        string regex = @"\+359([ -/])2\1\d{3}\1\d{4}\b";
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, regex);
        Console.Write(string.Join(", ", matches));
    }
}