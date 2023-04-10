using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var sum = double.Parse(Console.ReadLine());
        var ini = Console.ReadLine().Split().Select(int.Parse).ToList();
        var num = new List<int>(ini);
        string str;
        while ((str = Console.ReadLine()) != "Hit it again, Gabsy!") {
            int dmg = int.Parse(str);
            num = num.Select(x => x - dmg).ToList();
            for (int i = 0; i < num.Count; ++i) {
                if (num[i] <= 0) {//broken
                    if (sum >= ini[i] * 3) {//have money
                        sum -= ini[i] * 3;
                        num[i] = ini[i];
                    } else {//no money
                        ini.RemoveAt(i);
                        num.RemoveAt(i);
                    }
                }
            }
        }
        Console.WriteLine(String.Join(" ", num));
        Console.Write($"Gabsy has {sum:f2}lv.");
    }
}