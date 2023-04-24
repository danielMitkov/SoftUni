public class Threeuple<T1, T2, T3>
{
    private (T1, T2, T3) threeuple;
    public Threeuple(T1 item1,T2 item2,T3 item3)
    {
        threeuple = (item1, item2, item3);
    }
    public T1 Item1 { get => threeuple.Item1; }
    public T2 Item2 { get => threeuple.Item2; }
    public T3 Item3 { get => threeuple.Item3; }
}