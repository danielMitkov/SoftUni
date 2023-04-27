int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
int target = int.Parse(Console.ReadLine());
int start = 0;
int end = arr.Length - 1;
while(start <= end)
{
    int mid = (start + end) / 2;
    if(target < arr[mid])
    {
        end = mid - 1;
    }
    else if(target > arr[mid])
    {
        start = mid + 1;
    }
    else
    {
        Console.Write(mid);
        return;
    }
}
Console.Write(-1);
