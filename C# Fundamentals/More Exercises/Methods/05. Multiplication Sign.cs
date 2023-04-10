using System;
class Program {
    static void Main(string[] args) {
        int[] nums = { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
        int minuses = 0;
        bool isZero = false;
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] == 0) {
                isZero = true;
            }
            if (nums[i] < 0) {
                minuses++;
            }
        }
        if (isZero) {
            Console.WriteLine("zero");
            return;
        }
        if (minuses % 2 != 0) {
            Console.WriteLine("negative");
        } else {
            Console.WriteLine("positive");
        }
    }
}