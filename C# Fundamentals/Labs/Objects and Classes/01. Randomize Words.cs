using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var line = Console.ReadLine().Split().ToList();
        Random rnd = new Random();
        while (line.Count > 0) {
            int i = rnd.Next(0, line.Count);
            Console.WriteLine(line[i]);
            line.RemoveAt(i);
        }
    }
}