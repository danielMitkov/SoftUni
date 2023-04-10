using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool found = false;
        for (int i = 0; i < arr.Length; ++i) {
            int sumL = 0;
            for (int l = i - 1; l >= 0; --l) {
                sumL += arr[l];
            }
            int sumR = 0;
            for (int r = i + 1; r < arr.Length; ++r) {
                sumR += arr[r];
            }
            if (sumL == sumR) {
                Console.Write(i + " ");
                found = true;
            }
        }
        if (!found) {
            Console.Write("no");
        }
    }
}