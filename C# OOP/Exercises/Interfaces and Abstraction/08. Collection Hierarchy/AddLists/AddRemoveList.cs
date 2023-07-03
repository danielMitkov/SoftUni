namespace CollectionHierarchy.AddLists;
public class AddRemoveList : AddList, IRemovable
{
    public sealed override int Add(string str)
    {
        strings.Insert(0, str);
        return 0;
    }
    public virtual string Remove()
    {
        string str = strings.Last();
        strings.RemoveAt(strings.Count - 1);
        return str;
    }
}