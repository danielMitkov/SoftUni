int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
Console.WriteLine(nums.Count());
Console.Write(nums.Sum());
