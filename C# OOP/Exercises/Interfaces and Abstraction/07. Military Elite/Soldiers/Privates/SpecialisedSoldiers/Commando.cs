using System.Text;
namespace MilitaryElite.Soldiers.Privates.SpecialisedSoldiers;
public class Commando:SpecialisedSoldier
{
    public List<Mission> Missions { get; private set; }
    public Commando(string id,string fullName,decimal salary,string corps,string[] missionPairs)
        : base(id,fullName,salary,corps)
    {
        Missions = new();
        for(int i = 0;i < missionPairs.Length;i += 2)
        {
            string codeName = missionPairs[i];
            string state = missionPairs[i + 1];
            try
            {
                Missions.Add(new Mission(codeName,state));
            }
            catch(ArgumentException)
            {//continue for loop
            }
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        foreach(Mission mission in Missions)
        {
            sb.AppendLine(mission.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}