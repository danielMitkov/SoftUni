public class TupleClass<T1, T2>
{
    private (T1, T2) tuple;
    public TupleClass(T1 item1,T2 item2)
    {
        tuple = (item1, item2);
    }
    public T1 Item1 { get => tuple.Item1; }
    public T2 Item2 { get => tuple.Item2; }
}