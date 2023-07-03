using System.Text;
namespace MilitaryElite.Soldiers.Privates;
public class LieutenantGeneral:Private
{
    public List<Private> Privates { get; private set; }
    public LieutenantGeneral(string id,string fullName,decimal salary,List<Private> privates)
    : base(id,fullName,salary)
    {
        Privates = privates;
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach(Private privateSoldier in Privates)
        {
            sb.AppendLine("  " + privateSoldier.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}