Dictionary<string,Dictionary<string,int>> users = new();
Dictionary<string,int> languages = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "exam finished")
{
    string[] data = input.Split('-',StringSplitOptions.RemoveEmptyEntries);
    string name = data[0];
    if(data[1] == "banned")
    {
        users.Remove(name);
        continue;
    }
    string nameLanguage = data[1];
    int score = int.Parse(data[2]);
    if(!users.ContainsKey(name))
    {
        users.Add(name,new Dictionary<string,int>());
    }
    if(!users[name].ContainsKey(nameLanguage))
    {
        users[name].Add(nameLanguage,0);
    }
    if(score > users[name][nameLanguage])
    {
        users[name][nameLanguage] = score;
    }
    if(!languages.ContainsKey(nameLanguage))
    {
        languages.Add(nameLanguage,0);
    }
    languages[nameLanguage]++;
}
Console.WriteLine("Results:");
foreach(var (name, langs) in users.OrderByDescending(x => x.Value.Max(x => x.Value)).ThenBy(x => x.Key))
{
    Console.WriteLine($"{name} | {langs.Max(x => x.Value)}");
}
Console.WriteLine("Submissions:");
foreach(var (lang, submissions) in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{lang} - {submissions}");
}