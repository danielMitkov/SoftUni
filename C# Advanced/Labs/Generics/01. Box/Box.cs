namespace BoxOfT;
public class Box<T>
{
    private Stack<T> stk = new();
    public int Count { get { return stk.Count; } }
    public void Add(T element)
    {
        stk.Push(element);
    }
    public T Remove()
    {
        return stk.Pop();
    }
}