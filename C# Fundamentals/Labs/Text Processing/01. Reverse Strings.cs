using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var word = "";
        while ((word = Console.ReadLine()) != "end") Console.WriteLine($"{word} = {new string ( word.Reverse().ToArray() )}");
    }
}