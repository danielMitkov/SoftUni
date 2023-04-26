Func<int,int,int> comparer = (x,y) =>
{
    if(x % 2 == 0 && y % 2 != 0)
    {
        return -1;
    }
    if(x % 2 != 0 && y % 2 == 0)
    {
        return 1;
    }
    return x.CompareTo(y);
};
int[] arr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Array.Sort(arr,(x,y)=>comparer(x,y));
Console.WriteLine(string.Join(" ",arr));
