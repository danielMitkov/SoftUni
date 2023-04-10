using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        List<double> f = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
        List<double> s = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
        var result = new List<double>();
        int change = 1;
        while (f.Count > 0 || s.Count > 0) {
            if (change == 1 && f.Count > 0) {
                result.Add(f[0]);
                f.RemoveAt(0);
            }
            if (change == -1 && s.Count > 0) {
                result.Add(s[0]);
                s.RemoveAt(0);
            }
            change *= -1;
        }
        Console.WriteLine(String.Join(" ", result));
    }
}