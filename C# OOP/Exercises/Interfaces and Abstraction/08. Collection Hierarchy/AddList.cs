namespace CollectionHierarchy;
public class AddList
{
    protected List<string> strings;
    public AddList()
    {
        strings = new();
    }
    public virtual int Add(string str)
    {
        strings.Add(str);
        return strings.Count - 1;
    }
}