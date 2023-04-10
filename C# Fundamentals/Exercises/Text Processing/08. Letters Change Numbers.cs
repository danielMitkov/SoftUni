using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class SoftUni {
    static void Main() {
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var sum = 0m;
        for (int i = 0; i < input.Length; i++) {
            var first = input[i][0];
            var last = input[i].Last();
            var num = decimal.Parse(new string(input[i].Skip(1).SkipLast(1).ToArray()));
            if (char.IsUpper(first)) {
                num /= char.ToLower(first) - 96;// - 96 to get pos
            } else {
                num *= char.ToLower(first) - 96;
            }
            if (char.IsUpper(last)) {
                num -= char.ToLower(last) - 96;
            } else {
                num += char.ToLower(last) - 96;
            }
            sum += num;
        }
        Console.WriteLine($"{sum:f2}");
    }
}