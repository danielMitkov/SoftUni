namespace FootballTeamGenerator;
public class Team
{
    private Dictionary<string,Player> players = new();
    public double Rating
    {
        get
        {
            if(players.Any())
            {
                return players.Average(x => x.Value.SkillsAverage);
            }
            return 0;
        }
    }
    public void AddPlayer(string name,int[] skills)
    {
        int i = skills.ToList().FindIndex(x=>x < 0 || x > 100);
        if(i > -1)
        {
            string errSkill = string.Empty;
            switch(i)
            {
                case 0:
                    errSkill = "Endurance";
                    break;
                case 1:
                    errSkill = "Sprint";
                    break;
                case 2:
                    errSkill = "Dribble";
                    break;
                case 3:
                    errSkill = "Passing";
                    break;
                case 4:
                    errSkill = "Shooting";
                    break;
            }
            Console.WriteLine($"{errSkill} should be between 0 and 100.");
            return;
        }
        players.Add(name,new Player(skills));
    }
    public void RemovePlayer(string name,string teamName)
    {
        if(!players.ContainsKey(name))
        {
            Console.WriteLine($"Player {name} is not in {teamName} team.");
            return;
        }
        players.Remove(name);
    }
}