using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] nums = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < nums.Length; i++) {
            nums[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(String.Join(" ", nums.Reverse()));
    }
}