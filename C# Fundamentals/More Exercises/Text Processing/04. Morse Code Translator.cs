using System;
using System.Linq;
using System.Collections.Generic;
class SoftUni {
    static void Main() {
        var code = new Dictionary<string, char> {
            { ".-", 'A' }, { "-...", 'B' }, { "-.-.", 'C' }, { "-..", 'D' },{ ".", 'E' }, { "..-.", 'F' },
            { "--.", 'G' }, { "....", 'H' }, { "..", 'I' }, { ".---", 'J' }, { "-.-", 'K' },{ ".-..", 'L' },
            { "--", 'M' }, { "-.", 'N' }, { "---", 'O' }, { ".--.", 'P' },{ "--.-", 'Q' }, { ".-.", 'R' },
            { "...", 'S' }, { "-", 'T' }, { "..-", 'U' }, { "...-", 'V' }, { ".--", 'W' }, { "-..-", 'X' },
            { "-.--", 'Y' }, { "--..", 'Z' }
        };
        foreach (var word in Console.ReadLine().Split(" | ")) {
            foreach (var c in word.Split(' ', StringSplitOptions.RemoveEmptyEntries)) Console.Write(code[c]);
            Console.Write(' ');
        }
    }
}