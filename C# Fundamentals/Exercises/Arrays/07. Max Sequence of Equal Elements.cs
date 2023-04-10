using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int maxCount = 0;
        int maxElement = 0;
        for (int i = 0; i < arr.Length; ++i) {
            int currentCount = 0;
            int currentElement = arr[i];
            for (int r = i; r < arr.Length; ++r) {
                if (arr[r] == arr[i]) {
                    currentCount++;
                } else {
                    break;
                }
            }
            if (currentCount > maxCount) {
                maxCount = currentCount;
                maxElement = currentElement;
            }
        }
        for (int i = maxCount; i > 0; --i) {
            Console.Write(maxElement + " ");
        }
    }
}