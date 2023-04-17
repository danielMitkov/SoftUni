Dictionary<string,Vlogger> vloggers = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "Statistics")
{
    string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string name = data[0];
    string action = data[1];
    if(action == "joined")
    {
        if(!vloggers.ContainsKey(name))
        {
            vloggers.Add(name,new Vlogger());
        }
    }
    if(action == "followed")
    {
        string tobeFollowed = data[2];
        if(!vloggers.ContainsKey(name) || !vloggers.ContainsKey(tobeFollowed))
        {
            continue;
        }
        if(name == tobeFollowed)
        {
            continue;
        }
        if(vloggers[tobeFollowed].Followers.Contains(name))
        {
            continue;
        }
        vloggers[tobeFollowed].AddFollower(name);
        vloggers[name].AddFollowing();
    }
}
Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
var sorted = vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Followings).ToArray();
var top = sorted[0];
Console.WriteLine($"1. {top.Key} : {top.Value.Followers.Count} followers, {top.Value.Followings} following");
foreach(string name in top.Value.Followers)
{
    Console.WriteLine($"*  {name}");
}
for(int i = 1;i < sorted.Length;i++)
{
    var kvp = sorted[i];
    Console.WriteLine($"{i + 1}. {kvp.Key} : {kvp.Value.Followers.Count} followers, {kvp.Value.Followings} following");
}
public class Vlogger
{
    private int followings;
    private SortedSet<string> followers;
    public Vlogger()
    {
        followings = 0;
        followers = new();
    }
    public int Followings { get => followings; }
    public SortedSet<string> Followers { get => followers; }
    public void AddFollowing()
    {
        followings++;
    }
    public void AddFollower(string name)
    {
        followers.Add(name);
    }
}