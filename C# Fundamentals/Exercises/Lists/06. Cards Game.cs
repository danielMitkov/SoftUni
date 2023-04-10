using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        List<int> p1 = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<int> p2 = Console.ReadLine().Split().Select(int.Parse).ToList();
        while (true) {
            if (p1[0] > p2[0]) {
                p1.Add(p1[0]);
                p1.Add(p2[0]);
            } else if (p1[0] < p2[0]) {
                p2.Add(p2[0]);
                p2.Add(p1[0]);
            }
            p1.Remove(p1[0]);
            p2.Remove(p2[0]);
            if (p1.Count == 0) {
                int sum = p2.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
                break;
            } else if (p2.Count == 0) {
                int sum = p1.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
                break;
            }
        }
    }
}