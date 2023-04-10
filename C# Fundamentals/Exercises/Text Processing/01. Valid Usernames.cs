using System;
using System.Linq;
class SoftUni {
    static void Main() {
        var names = Console.ReadLine().Split(", ");
        foreach (var name in names) {
            if (name.Length < 3 || name.Length > 16) continue;
            var valid = true;
            foreach (var c in name) if (!char.IsLetter(c) && !char.IsDigit(c) && c != '-' && c != '_') valid = false;
            if (valid) Console.WriteLine(name);
        }
    }
}