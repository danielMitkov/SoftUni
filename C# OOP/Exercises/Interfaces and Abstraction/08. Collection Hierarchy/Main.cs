using CollectionHierarchy;
using CollectionHierarchy.AddLists;
using CollectionHierarchy.AddLists.AddRemoveLists;
AddList addList = new();
AddRemoveList addRemoveList = new();
MyList myList = new();
List<AddList> addLists = new()
{
    addList,
    addRemoveList,
    myList
};
List<IRemovable> removeLists = new()
{
    addRemoveList,
    myList
};
string[] addData = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
foreach(AddList list in addLists)
{
    int[] indexes = new int[addData.Length];
    for(int i = 0;i < indexes.Length;++i)
    {
        indexes[i] = list.Add(addData[i]);
    }
    Console.WriteLine(string.Join(' ',indexes));
}
int removeCalls = int.Parse(Console.ReadLine());
foreach(IRemovable removable in removeLists)
{
    string[] strings = new string[removeCalls];
    for(int i = 0;i < removeCalls;++i)
    {
        strings[i] = removable.Remove();
    }
    Console.WriteLine(string.Join(' ',strings));
}