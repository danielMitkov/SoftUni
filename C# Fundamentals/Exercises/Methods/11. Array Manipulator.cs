using System.Collections.Generic;
using System.Linq;
using System;
public class Program
{
    public static void Main()
    {
        int[] nums = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        string line = string.Empty;
        while((line = Console.ReadLine()) != "end")
        {
            string[] data = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string command = data[0];
            switch(command)
            {
                case "exchange":
                    int index = int.Parse(data[1]);
                    if(index < 0 || index >= nums.Length)
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }
                    int[] first = nums[..(index+1)];
                    int[] second = nums[(index+1)..];
                    nums = second.Concat(first).ToArray();
                    break;
                case "max":
                    bool isOdd = data[1] == "odd";
                    int max = -1;//number, not index
                    for(int i = 0;i < nums.Length;++i)
                    {
                        if(isOdd && nums[i] % 2 != 0 && nums[i] >= max)
                        {
                            max = nums[i];
                        }
                        if(!isOdd && nums[i] % 2 == 0 && nums[i] >= max)
                        {
                            max = nums[i];
                        }
                    }
                    if(max == -1)
                    {
                        Console.WriteLine("No matches");
                        break;
                    }
                    Console.WriteLine(nums.ToList().LastIndexOf(max));
                    break;
                case "min":
                    isOdd = data[1] == "odd";
                    int min = int.MaxValue;//number, not index
                    for(int i = 0;i < nums.Length;++i)
                    {
                        if(isOdd && nums[i] % 2 != 0 && nums[i] <= min)
                        {
                            min = nums[i];
                        }
                        if(!isOdd && nums[i] % 2 == 0 && nums[i] <= min)
                        {
                            min = nums[i];
                        }
                    }
                    if(min == int.MaxValue)
                    {
                        Console.WriteLine("No matches");
                        break;
                    }
                    Console.WriteLine(nums.ToList().LastIndexOf(min));
                    break;
                case "first":
                    int count = int.Parse(data[1]);
                    if(count > nums.Length)
                    {
                        Console.WriteLine("Invalid count");
                        break;
                    }
                    isOdd = data[2] == "odd";
                    List<int> result = new List<int>();
                    for(int i = 0;i < nums.Length;++i)
                    {
                        if(isOdd && nums[i] % 2 != 0)
                        {
                            result.Add(nums[i]);
                        }
                        if(!isOdd && nums[i] % 2 == 0)
                        {
                            result.Add(nums[i]);
                        }
                        if(result.Count == count)
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"[{string.Join(", ",result)}]");
                    break;
                case "last":
                    count = int.Parse(data[1]);
                    if(count > nums.Length)
                    {
                        Console.WriteLine("Invalid count");
                        break;
                    }
                    isOdd = data[2] == "odd";
                    result = new List<int>();
                    for(int i = nums.Length - 1;i >= 0;--i)
                    {
                        if(isOdd && nums[i] % 2 != 0)
                        {
                            result.Insert(0,nums[i]);
                        }
                        if(!isOdd && nums[i] % 2 == 0)
                        {
                            result.Insert(0,nums[i]);
                        }
                        if(result.Count == count)
                        {
                            break;
                        }
                    }
                    Console.WriteLine($"[{string.Join(", ",result)}]");
                    break;
            }
        }
        Console.Write($"[{string.Join(", ",nums)}]");
    }
}