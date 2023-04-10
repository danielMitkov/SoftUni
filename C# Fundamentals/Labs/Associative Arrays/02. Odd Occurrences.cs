using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var words = Console.ReadLine().Split();
        var counts = new Dictionary<string, int>();
        foreach (var word in words.Select(x => x.ToLower())) {
            if (counts.ContainsKey(word)) {
                counts[word]++;
            } else {
                counts.Add(word, 1);
            }
        }
        foreach (var kvp in counts) {
            if (kvp.Value % 2 != 0) {
                System.Console.Write(kvp.Key + " ");
            }
        }
    }
}