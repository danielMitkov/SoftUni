using System.Collections;

namespace Custom_Stack;
public class CustomStack<T>:IEnumerable<T>
{
    private Stack<T> _stack;

    public CustomStack()
    {
        _stack = new Stack<T>();
    }

    public void Push(params T[] items)
    {
        foreach(T item in items)
        {
            _stack.Push(item);
        }
    }
    public void Pop()
    {
        if(_stack.Any())
        {
            _stack.Pop();
            return;
        }
        Console.WriteLine("No elements");
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach(T item in _stack)
        {
            yield return item;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}