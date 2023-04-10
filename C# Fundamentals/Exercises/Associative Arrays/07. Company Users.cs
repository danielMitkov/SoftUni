using System;
using System.Collections.Generic;
using System.Linq;
class Program {
    static void Main() {
        var dic = new Dictionary<string, List<string>>();
        while(true) {
            string[] data = { Console.ReadLine() };
            if (data[0] == "End") break;
            data = data[0].Split(" -> ");
            if (!dic.ContainsKey(data[0]))
                dic[data[0]] = new List<string>() { data[1] };
            else if (!dic[data[0]].Contains(data[1])) 
                dic[data[0]].Add(data[1]);
        }
        foreach (var kvp in dic) {
            Console.WriteLine(kvp.Key);
            foreach (var id in kvp.Value) {
                Console.WriteLine("-- " + id);
            }
        }
    }
}