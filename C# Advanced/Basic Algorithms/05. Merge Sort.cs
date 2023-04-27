var nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();
var left = nums.Take(nums.Count / 2).ToList();
nums.RemoveRange(0,nums.Count / 2);
var right = nums;
static List<decimal> MergeSort(List<decimal> unsortedLeft,List<decimal> unsortedRight)
{
    if(unsortedLeft.Count + unsortedRight.Count == 1)
    {
        return new List<decimal>(unsortedLeft.Concat(unsortedRight));
    }
    var left = unsortedLeft.Take(unsortedLeft.Count / 2).ToList();
    unsortedLeft.RemoveRange(0,unsortedLeft.Count / 2);
    var right = unsortedLeft;
    var sortedLeft = MergeSort(left,right);
    left = unsortedRight.Take(unsortedRight.Count / 2).ToList();
    unsortedRight.RemoveRange(0,unsortedRight.Count / 2);
    right = unsortedRight;
    var sortedRight = MergeSort(left,right);
    var result = new decimal[sortedLeft.Count + sortedRight.Count];
    for(int i = 0;i < result.Length;++i)
    {
        if(!sortedLeft.Any())
        {
            result[i] = sortedRight[0];
            sortedRight.RemoveAt(0);
            continue;
        }
        if(!sortedRight.Any())
        {
            result[i] = sortedLeft[0];
            sortedLeft.RemoveAt(0);
            continue;
        }
        if(sortedLeft[0] <= sortedRight[0])
        {
            result[i] = sortedLeft[0];
            sortedLeft.RemoveAt(0);
            continue;
        }
        if(sortedRight[0] < sortedLeft[0])
        {
            result[i] = sortedRight[0];
            sortedRight.RemoveAt(0);
        }
    }
    return result.ToList();
}
Console.Write(string.Join(" ",MergeSort(left,right)));
