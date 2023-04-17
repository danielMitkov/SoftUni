HashSet<string> vip = new();
HashSet<string> reg = new();
bool isParty = false;
var str = string.Empty;
while((str = Console.ReadLine()) != "END")
{
    if(str == "PARTY")
    {
        isParty = true;
        continue;
    }
    if(isParty)
    {
        if(vip.Contains(str))
        {
            vip.Remove(str);
        }
        if(reg.Contains(str))
        {
            reg.Remove(str);
        }
    }
    else
    {
        if(char.IsDigit(str[0]))
        {
            vip.Add(str);
        }
        else
        {
            reg.Add(str);
        }
    }
}
Console.WriteLine(vip.Count + reg.Count);
if(vip.Any())
{
    Console.WriteLine(string.Join("\n",vip));
}
if(reg.Any())
{
    Console.WriteLine(string.Join("\n",reg));
}