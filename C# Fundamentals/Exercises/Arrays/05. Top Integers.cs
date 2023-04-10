using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < arr.Length; ++i) {
            bool isTop = true;
            for (int r = i + 1; r < arr.Length; ++r) {
                if (arr[i] <= arr[r]) {
                    isTop = false;
                }
            }
            if (isTop) {
                Console.Write(arr[i] + " ");
            }
        }
    }
}