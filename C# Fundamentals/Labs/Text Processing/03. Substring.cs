using System;
class SoftUni {
    static void Main() {
        var word = Console.ReadLine();
        var text = Console.ReadLine();
        while(text.Contains(word)) text = text.Replace(word, "");
        Console.WriteLine(text);
    }
}