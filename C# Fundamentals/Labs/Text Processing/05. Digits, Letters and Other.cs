using System;
using System.Linq;
class SoftUni {
    static void Main() {
        var text = Console.ReadLine();
        Console.WriteLine(new string(text.Where(x => char.IsDigit(x)).ToArray()));
        Console.WriteLine(new string(text.Where(x => char.IsLetter(x)).ToArray()));
        Console.WriteLine(new string(text.Where(x => !char.IsDigit(x) && !char.IsLetter(x)).ToArray()));
    }
}