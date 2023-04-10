using System;
using System.Collections.Generic;
class SoftUni {
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        var items = new List<string>();
        for (int i = 0; i < n; i++) {
            items.Add(Console.ReadLine());
        }
        items.Sort();
        for (int i = 0; i < n; ++i) {
            Console.WriteLine($"{i + 1}.{items[i]}");
        }
    }
}