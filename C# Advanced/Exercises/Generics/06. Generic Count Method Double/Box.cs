public class Box<T> where T : IComparable<T>
{
    private T thing;
    public Box(T thing)
    {
        this.thing = thing;
    }
    public T Thing { get => thing; }
    public int GetComparison(List<Box<T>> list)
    {
        int count = 0;
        foreach(Box<T> item in list)
        {
            if(thing.CompareTo(item.Thing) == -1)
            {
                count++;
            }
        }
        return count;
    }
    public override string ToString()
    {
        return $"{thing.GetType()}: {thing}";
    }
}