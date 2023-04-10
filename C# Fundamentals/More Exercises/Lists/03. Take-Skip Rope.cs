using System;
using System.Linq;
class SoftUni {
    static void Main() {
        var input = Console.ReadLine();
        var nums = input.Where(x => char.IsDigit(x)).Select(x => x - '0');
        var text = input.Where(x => !char.IsDigit(x));
        var skip = nums.Where((x, i) => i % 2 != 0).ToList();
        var take = nums.Where((x, i) => i % 2 == 0).ToList();
        for (int i = 0; i < take.Count; i++) {
            Console.Write(text.Take(take[i]).ToArray());
            text = text.Skip(take[i] + skip[i]).ToArray();
        }
    }
}