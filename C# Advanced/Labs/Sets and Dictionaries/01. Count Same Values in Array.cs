double[] nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
Dictionary<double,int> dict = new();
for(int i = 0;i<nums.Length;i++) {
    if(!dict.ContainsKey(nums[i])) dict.Add(nums[i],0);
    dict[nums[i]]+=1;
}
foreach(var kvp in dict) Console.WriteLine($"{kvp.Key} - {kvp.Value} times");