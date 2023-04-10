using System.Collections.Generic;
using System.Linq;
using System;
public class Program
{
    public static void Main()
    {
        int[] nums = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        List<int[]> sequences = new List<int[]>();
        for(int i = nums.Length - 1;i >= 0;--i)
        {
            int num = nums[i];
            int[][] potencials = sequences.Where(x => x[0] > num).Reverse().OrderByDescending(x => x.Length).ToArray();
            if(!potencials.Any())
            {
                sequences.Add(new int[] { num });
                continue;
            }
            sequences.Add(new int[] { num }.Concat(potencials.First()).ToArray());
        }
        sequences.Reverse();
        Console.Write(string.Join(" ",sequences.OrderByDescending(x => x.Length).First()));
    }
}