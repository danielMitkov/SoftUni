using System;
using System.Collections.Generic;
using System.Linq;
class Program {
    static void Main() {
        var dic = new Dictionary<string, int>();
        while (true) {
            var line = Console.ReadLine();
            if (line == "stop") break;
            var thing = line;
            var count = int.Parse(Console.ReadLine());
            if (dic.ContainsKey(thing)) dic[thing] += count;
            else dic.Add(thing, count);
        }
        Console.Write(String.Join('\n', dic
            .Select(x => $"{x.Key} -> {x.Value}")));
    }
}