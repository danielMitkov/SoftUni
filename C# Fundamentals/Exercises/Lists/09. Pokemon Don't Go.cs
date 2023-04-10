using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var list = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int sum = 0;
        while (list.Count > 0) {
            int target = int.Parse(Console.ReadLine()!);
            int value = 0;
            if (target < 0) {
                value = list[0];
                list.RemoveAt(0);
                list.Insert(0, list[list.Count - 1]);
            } else if (target > list.Count - 1) {
                target = list.Count - 1;
                value = list[target];
                list.RemoveAt(target);
                list.Add(list[0]);
            } else {
                value = list[target];
                list.RemoveAt(target);
            }
            sum += value;
            for (int i = 0; i < list.Count; ++i) {
                if (list[i] <= value) { 
                    list[i] += value;
                    continue;
                }
                if (list[i] > value) list[i] -= value;
            }
        }
        Console.Write(sum);
    }
}