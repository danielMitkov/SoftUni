using System;
using System.Collections;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            var nums = new ArrayList();
            int sum = 0;
            int max = 0;
            for (int i = 0; i < n; ++i) {
                nums.Add(int.Parse(Console.ReadLine()));
                sum += (int)nums[i];
                max = (int)nums[i] > max ? (int)nums[i] : max;
            }
            bool isThere = false;
            int theChosenOne = 0;
            for (int i = 0; i < n; ++i) {
                if (sum - (int)nums[i] == (int)nums[i]) {
                    isThere = true;
                    theChosenOne = (int)nums[i];
                    break;
                }
            }
            if (isThere) {
                Console.WriteLine($"Yes\nSum = {theChosenOne}");
            } else {
                nums.Remove(max);
                Console.WriteLine($"No\nDiff = {Math.Abs(max - (sum - max))}");
            }
        }
    }
}