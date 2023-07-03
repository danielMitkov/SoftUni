namespace CollectionHierarchy.AddLists.AddRemoveLists;
public class MyList : AddRemoveList
{
    public int Used => strings.Count;
    public override string Remove()
    {
        string str = strings.First();
        strings.RemoveAt(0);
        return str;
    }
}