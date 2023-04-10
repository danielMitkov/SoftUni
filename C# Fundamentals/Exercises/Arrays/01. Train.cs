using System;
using System.Linq;
class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; ++i) {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(String.Join(" ", arr));
        int sum = 0;
        foreach(int num in arr) {
            sum += num;
        }
        Console.WriteLine(sum);
    }
}