namespace FootballTeamGenerator;
public class Player
{
    private int[] skills;
    public Player(int[] skills)
    {
        this.skills = skills.ToArray();
    }
    public double SkillsAverage => skills.Average();
}