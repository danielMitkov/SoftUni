SortedDictionary<string,SortedSet<string>> sides = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "Lumpawaroo")
{
    string[] data = null;
    string side = string.Empty;
    string user = string.Empty;
    if(input.Contains(" -> "))
    {
        data = input.Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
        user = data[0];
        side = data[1];
        foreach(var (sideName, set) in sides)
        {
            if(set.Contains(user))
            {
                set.Remove(user);
            }
            if(sides[sideName].Count == 0)
            {
                sides.Remove(sideName);
            }
            break;
        }
        Console.WriteLine($"{user} joins the {side} side!");
    }
    if(input.Contains(" | "))
    {
        data = input.Split(" | ",StringSplitOptions.RemoveEmptyEntries);
        side = data[0];
        user = data[1];
    }
    if(sides.Values.Any(x => x.Contains(user)))
    {
        continue;
    }
    if(!sides.ContainsKey(side))
    {
        sides.Add(side,new SortedSet<string>());
    }
    if(!sides[side].Contains(user))
    {
        sides[side].Add(user);
    }
}
foreach(var (side, set) in sides.OrderByDescending(x => x.Value.Count))
{
    Console.WriteLine($"Side: {side}, Members: {set.Count}");
    foreach(string user in set)
    {
        Console.WriteLine($"! {user}");
    }
}