using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class SoftUni {
    static void Main() {
        var str = new StringBuilder(Console.ReadLine());
        int dmg = 0;
        for (int i = 0; i < str.Length; ++i) {
            if (str[i] == '>') {
                dmg += str[i + 1] - 1 - '0';
                str.Remove(i + 1, 1);
                continue;
            }
            if (str[i] != '>' && dmg > 0) {
                str.Remove(i, 1);
                dmg--;
                i--;
            }
        }
        Console.WriteLine(str.ToString());
    }
}