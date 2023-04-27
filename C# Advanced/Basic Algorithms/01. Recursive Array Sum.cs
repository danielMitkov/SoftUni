int[] nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
static int CalcSum(int[] nums,int index)
{
    if(index == nums.Length - 1)
    {
        return nums[index];
    }
    return nums[index] + CalcSum(nums,index + 1);
}
static int Sum(int[] nums)
{
    return CalcSum(nums,0);
}
Console.Write(Sum(nums));
