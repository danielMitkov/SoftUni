using System;
using System.Linq;

class Program {
    static void Main(string[] args) {
        int[] arrA = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] arrB = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = 0;
        for (int i = 0; i < arrA.Length; ++i) {
            if (arrA[i] != arrB[i]) {
                Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                return;
            }
            sum += arrA[i];
        }
        Console.WriteLine($"Arrays are identical. Sum: {sum}");
    }
}