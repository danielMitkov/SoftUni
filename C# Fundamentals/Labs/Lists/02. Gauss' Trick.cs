using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        List<double> nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
        var result = new List<double>();
        int f = 0;
        int l = nums.Count - 1;
        while (f < nums.Count / 2) {
            result.Add(nums[f] + nums[l]);
            f++;
            l--;
        }
        if (nums.Count % 2 != 0) {
            result.Add(nums[nums.Count / 2]);
        }
        Console.WriteLine(String.Join(" ", result));
    }
}