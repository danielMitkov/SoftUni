int[] nums = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();
for(int i = 0;i<nums.Length&&i<3;i++) Console.Write(nums[i]+" ");