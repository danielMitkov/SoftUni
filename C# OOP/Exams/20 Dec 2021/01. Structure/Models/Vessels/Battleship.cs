using System.Text;

namespace NavalVessels.Models.Vessels;
public class Battleship:Vessel
{
    private bool sonarMode;
    public bool SonarMode
    {
        get { return sonarMode; }
        private set { sonarMode = value; }
    }
    public Battleship(string name,double mainWeaponCaliber,double speed)
        : base(name,mainWeaponCaliber,speed,300)
    {
        defaultArmor = 300;
        SonarMode = false;
    }
    public void ToggleSonarMode()
    {
        SonarMode = !SonarMode;
        if(SonarMode)
        {
            MainWeaponCaliber += 40;
            Speed -= 5;
        }
        else
        {
            MainWeaponCaliber -= 40;
            Speed += 5;
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        if(SonarMode)
        {
            sb.Append($" *Sonar mode: ON");
        }
        else
        {
            sb.Append($" *Sonar mode: OFF");
        }
        return sb.ToString();
    }
}
