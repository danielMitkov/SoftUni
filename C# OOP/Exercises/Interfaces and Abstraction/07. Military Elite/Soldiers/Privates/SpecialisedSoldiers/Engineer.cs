using System.Text;
namespace MilitaryElite.Soldiers.Privates.SpecialisedSoldiers;
public class Engineer:SpecialisedSoldier
{
    public List<Repair> Repairs { get; private set; }
    public Engineer(string id,string fullName,decimal salary,string corps,string[] repairPairs)
        : base(id,fullName,salary,corps)
    {
        Repairs = new();
        for(int i = 0;i < repairPairs.Length;i += 2)
        {
            string partName = repairPairs[i];
            int hoursWorked = int.Parse(repairPairs[i + 1]);
            Repairs.Add(new Repair(partName,hoursWorked));
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Repairs:");
        foreach(Repair repair in Repairs)
        {
            sb.AppendLine(repair.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}