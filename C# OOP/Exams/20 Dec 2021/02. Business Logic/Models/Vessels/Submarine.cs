using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models.Vessels;
public class Submarine:Vessel
{
    private bool submergeMode;
    public bool SubmergeMode
    {
        get { return submergeMode; }
        private set { submergeMode = value; }
    }

    public Submarine(string name,double mainWeaponCaliber,double speed) 
        : base(name,mainWeaponCaliber,speed,200)
    {
        defaultArmor = 200;
        SubmergeMode = false;
    }
    public void ToggleSubmergeMode()
    {
        SubmergeMode = !SubmergeMode;
        if(SubmergeMode)
        {
            MainWeaponCaliber += 40;
            Speed -= 4;
        }
        else
        {
            MainWeaponCaliber -= 40;
            Speed += 4;
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ToString());
        if(SubmergeMode)
        {
            sb.Append($" *Submerge mode: ON");
        }
        else
        {
            sb.Append($" *Submerge mode: OFF");
        }
        return sb.ToString();
    }
}
