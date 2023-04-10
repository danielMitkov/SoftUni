using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var words = Console.ReadLine().Split();
        foreach (var word in words) foreach (var letter in word) Console.Write(word);
    }
}