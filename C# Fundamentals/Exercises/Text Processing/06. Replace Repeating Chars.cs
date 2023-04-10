using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class SoftUni {
    static void Main() {
        var str = new StringBuilder(Console.ReadLine());
        var c = str[0];
        for (int i = 1; i < str.Length; ++i) {
            if (str[i] == c) {
                str.Remove(i, 1);
                i--;
            } else c = str[i];
        }
        Console.WriteLine(str.ToString());
    }
}