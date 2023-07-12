int[] nums = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int exceptionCount = 0;
while(exceptionCount < 3)
{
    string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string command = data[0];
    try
    {
        int index = int.Parse(data[1]);
        switch(command)
        {
            case "Replace":
                int num = int.Parse(data[2]);
                nums[index] = num;
                break;
            case "Print":
                int end = int.Parse(data[2]);
                if(end < 0 || end >= nums.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine(string.Join(", ",nums[index..(end+1)]));
                break;
            case "Show":
                Console.WriteLine(nums[index]);
                break;
        }
    }
    catch(FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        exceptionCount++;
    }
    catch(ArgumentOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionCount++;
    }
    catch(IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionCount++;
    }
}
Console.Write(string.Join(", ",nums));
