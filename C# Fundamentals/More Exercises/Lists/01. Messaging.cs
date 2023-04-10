using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        List<char> str = new List<char>();
        str.AddRange(Console.ReadLine());
        for (int i = 0; i < nums.Count; ++i) {
            int sum = 0;
            while (nums[i] != 0) {
                sum += nums[i] % 10;
                nums[i] /= 10;
            }
            int times = sum / str.Count;
            sum = sum - times * str.Count;
            Console.Write(str[sum]);
            str.RemoveAt(sum);
        }
    }
}