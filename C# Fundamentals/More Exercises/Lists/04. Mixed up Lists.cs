using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var f = Console.ReadLine().Split().Select(int.Parse).ToList();
        var s = Console.ReadLine().Split().Select(int.Parse).ToList();
        var size = f.Count < s.Count ? f : s;
        var mix = new int[size.Count * 2];
        for (int i = 0; i < mix.Length; ++i) {
            if (i % 2 == 0) {
                mix[i] = f[0];
                f.RemoveAt(0);
            } else {
                mix[i] = s[s.Count - 1];
                s.RemoveAt(s.Count - 1);
            }
        }
        var b = f.Count > s.Count ? f : s;
        int[] range = { b[0] < b[1] ? b[0] : b[1], b[0] > b[1] ? b[0] : b[1] };
        var output = new List<int>();
        for (int i = 0; i < mix.Length; ++i) {
            if (mix[i] > range[0] && mix[i] < range[1]) {
                output.Add(mix[i]);
            }
        }
        output.Sort();
        Console.WriteLine(string.Join(" ", output));
    }
}