using System;
using System.Linq;
using System.Text;
class SoftUni {
    static void Main() {
        var sb = new StringBuilder(Console.ReadLine());
        for (int i = 0; i < sb.Length; ++i) sb.Replace(sb[i], (char)(sb[i] + 3), i, 1);
        Console.WriteLine(sb.ToString());
    }
}