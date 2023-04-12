using System;
using System.Linq;
using System.Collections.Generic;
class SoftUni {
    static void Main() {
        var n = int.Parse(Console.ReadLine());
        var pos = Console.ReadLine().Split().Select(int.Parse).ToList();
        for (int i = 0; i < pos.Count; ++i) {
            if (n <= 0) {
                break;
            }
            while (pos[i] < 4 && n > 0) {
                pos[i] += 1;
                n -= 1;
            }
        }
        for (int i = 0; i < pos.Count; ++i) {
            if (pos[i] < 4) {
                Console.WriteLine("The lift has empty spots!");
                break;
            }
        }
        if (n > 0) {
            Console.WriteLine($"There isn't enough space! {n} people in a queue!");
        }
        Console.WriteLine(String.Join(" ", pos));
    }
}