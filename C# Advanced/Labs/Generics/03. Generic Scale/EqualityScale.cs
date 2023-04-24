namespace GenericScale;
public class EqualityScale<T> where T : IComparable<T>
{
    private T left;
    private T right;
    public EqualityScale(T left,T right)
    {
        this.left = left;
        this.right = right;
    }
    public T Left { get => left; set => left = value; }
    public T Right { get => right; set => right = value; }
    public bool AreEqual()
    {
        return left.CompareTo(right) == 0;
    }
}