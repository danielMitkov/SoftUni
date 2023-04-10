using System;
class SoftUni {
    static void Main() {
        var bans = Console.ReadLine().Split(", ");
        var text = Console.ReadLine();
        foreach (var word in bans) {
            text = text.Replace(word, new string('*', word.Length));
        }
        Console.WriteLine(text);
    }
}