using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int r = int.Parse(Console.ReadLine()); r > 0; --r) {
            for (int i = 0; i < arr.Length - 1; ++i) {
                (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
            }
        }
        Console.WriteLine(String.Join(" ", arr));
    }
}