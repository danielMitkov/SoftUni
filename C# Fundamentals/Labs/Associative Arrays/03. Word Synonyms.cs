using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        int data = int.Parse(Console.ReadLine());
        var dic = new Dictionary<string, List<string>>();
        for (int i = 0; i < data; i++) {
            string key = Console.ReadLine();
            if (!dic.ContainsKey(key)) {
                dic.Add(key, new List<string>());
            }
            dic[key].Add(Console.ReadLine());
        }
        foreach (var kvp in dic) {
            Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
        }
    }
}