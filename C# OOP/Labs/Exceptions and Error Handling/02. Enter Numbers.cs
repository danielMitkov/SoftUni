int[] nums = new int[10];
int i = 0;
while(i < nums.Length)
{
    try
    {
        nums[i] = ReadNumber(i == 0 ? 1 : nums[i - 1],100);
        i++;
    }
    catch(ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch(Exception)
    {
        Console.WriteLine("Invalid Number!");
    }
}
Console.WriteLine(string.Join(", ",nums));
static int ReadNumber(int start,int end)
{
    int num = int.Parse(Console.ReadLine());
    if(num <= start || num >= end)
    {
        throw new ArgumentException($"Your number is not in range {start} - 100!");
    }
    return num;
}
