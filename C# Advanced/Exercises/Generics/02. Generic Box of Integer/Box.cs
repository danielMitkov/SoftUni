public class Box<T>
{
    private T thing;
    public Box(T thing)
    {
        this.thing = thing;
    }
    public override string ToString()
    {
        return $"{thing.GetType()}: {thing}";
    }
}