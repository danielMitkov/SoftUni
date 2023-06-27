using FootballTeamGenerator;
Dictionary<string,Team> teams = new();
string input = string.Empty;
while((input = Console.ReadLine()) != "END")
{
    string[] data = input.Replace(" ","").Split(';',StringSplitOptions.RemoveEmptyEntries);
    string action = data[0];
    string teamName = data[1];
    if(string.IsNullOrWhiteSpace(teamName))
    {
        Console.WriteLine("A name should not be empty.");
        continue;
    }
    switch(action)
    {
        case "Team":
            teams.Add(teamName,new Team());
            break;
        case "Add":
            if(!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                continue;
            }
            string playerName = data[2];
            teams[teamName].AddPlayer(playerName,data.Skip(3).Select(int.Parse).ToArray());
            break;
        case "Remove":
            string namePlayer = data[2];
            teams[teamName].RemovePlayer(namePlayer,teamName);
            break;
        case "Rating":
            if(!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                continue;
            }
            Console.WriteLine($"{teamName} - {teams[teamName].Rating:F0}");
            break;
    }
}