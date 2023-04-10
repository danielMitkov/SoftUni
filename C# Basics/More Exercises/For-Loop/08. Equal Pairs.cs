using System;
using System.Collections;

namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine()) * 2;
            
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i) {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int sum = arr[0] + arr[1];
            bool isYes = true;
            var arlist = new ArrayList();//4 0,1 2,3
            for (int i = 0; i < arr.Length; i += 2) {
                if (arr[i] + arr[i + 1] != sum) {
                    isYes = false;
                }
                arlist.Add(arr[i] + arr[i + 1]);
            }
            if (isYes) {
                Console.WriteLine($"Yes, value={sum}");
            } else {
                int diff = int.MinValue;
                
                for (int i = 0; i < arlist.Count - 1; ++i) {//4 0,1 1,2 2,3
                    if (Math.Abs((int)arlist[i] - (int)arlist[i + 1]) > diff) {
                        diff = Math.Abs((int)arlist[i] - (int)arlist[i + 1]);
                    }
                }
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}