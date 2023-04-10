using System;
using System.Text.RegularExpressions;
class SoftUni {
    static void Main() {
        var names = Regex.Matches(Console.ReadLine(), @"\b[A-Z][a-z]+ \b[A-Z][a-z]+");
        Console.Write(string.Join(' ', names));
    }
}