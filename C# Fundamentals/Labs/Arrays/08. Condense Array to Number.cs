using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        while (arr.Length > 1) {
            int[] arrSmall = new int[arr.Length - 1];
            for (int i = 0; i < arrSmall.Length; ++i) {
                arrSmall[i] = arr[i] + arr[i + 1];
            }
            arr = arrSmall;
        }
        Console.WriteLine(arr[0]);
    }
}