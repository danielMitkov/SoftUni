using BorderControl;
using BorderControl.BaseIds;
List<IId> ids = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "End")
{
    string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string name = data[0];
    string id = data.Last();
    if(data.Length == 3)
    {
        int age = int.Parse(data[1]);
        ids.Add(new Citizen(name,age,id));
    }
    else
    {
        ids.Add(new Robot(name,id));
    }
}
string fakeIdNums = Console.ReadLine();
foreach(IId id in ids)
{
    if(id.Id.EndsWith(fakeIdNums))
    {
        Console.WriteLine(id.Id);
    }
}