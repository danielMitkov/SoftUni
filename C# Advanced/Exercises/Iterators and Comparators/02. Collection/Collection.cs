using System.Collections;

namespace Listy_Iterator;
public class ListyIterator<T>:IEnumerable<T>
{
    private List<T> _list;
    private int _index;
    public ListyIterator(IEnumerable<T> items)
    {
        _list = items.ToList();
        _index = 0;
    }
    public bool Move()
    {
        if(HasNext())
        {
            _index++;
            return true;
        }
        return false;
    }
    public void Print()
    {
        if(_list.Any())
        {
            Console.WriteLine(_list[_index]);
            return;
        }
        Console.WriteLine("Invalid Operation!");
    }
    public bool HasNext() => _index < _list.Count - 1;
    public IEnumerator<T> GetEnumerator()
    {
        foreach(T item in _list)
        {
            yield return item;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}