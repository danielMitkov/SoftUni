using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = int.Parse(Console.ReadLine());
        for (int i = 0; i < arr.Length; ++i) {
            for (int r = i + 1; r < arr.Length; ++r) {
                if (arr[i] + arr[r] == sum) {
                    Console.WriteLine(arr[i] + " " + arr[r]);
                }
            }
        }
    }
}