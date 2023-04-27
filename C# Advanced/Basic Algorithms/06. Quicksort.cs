static int Partition<T>(T[] a,int lo,int hi) where T : IComparable<T>
{
    if(lo >= hi)
    {
        return lo;
    }
    int l = lo - 1;
    int h = hi;
    while(true)
    {
        while(a[++l].CompareTo(a[hi]) < 0)
        {
            if(l == hi)
            {
                break;
            }
        }
        while(a[--h].CompareTo(a[hi]) > 0)
        {
            if(h == lo)
            {
                break;
            }
        }
        if(l >= h)
        {
            break;
        }
        (a[l], a[h]) = (a[h], a[l]);
    }
    (a[hi], a[l]) = (a[l], a[hi]);
    return l;
}
static void Sort<T>(T[] a,int lo,int hi) where T : IComparable<T>
{
    if(lo >= hi)
    {
        return;
    }
    int p = Partition(a,lo,hi);
    Sort(a,lo,p - 1);
    Sort(a,p + 1,hi);
}
static void Shuffle<T>(T[] a) where T : IComparable<T>
{
    Random rand = new();
    for(int i = 0;i < a.Length;i++)
    {
        int r = rand.Next(0,a.Length);
        (a[i], a[r]) = (a[r], a[i]);
    }
}
static void QuickSort<T>(T[] items) where T : IComparable<T>
{
    Shuffle(items);
    Sort(items,0,items.Length - 1);
}
int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
QuickSort(arr);
Console.Write(string.Join(" ",arr));
