using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models;
public abstract class Vessel:IVessel
{
    private string name;
    public string Name
    {
        get { return name; }
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Vessel name cannot be null or empty.");
            }
            name = value;
        }
    }
    private ICaptain captain;
    public ICaptain Captain
    {
        get { return captain; }
        set
        {
            if(value == null)
            {
                throw new NullReferenceException("Captain cannot be null.");
            }
            captain = value;
        }
    }
    private double armorThicknessyVar;
    public double ArmorThickness
    {
        get { return armorThicknessyVar; }
        set { armorThicknessyVar = value; }
    }
    private double mainWeaponCaliber;
    public double MainWeaponCaliber
    {
        get { return mainWeaponCaliber; }
        protected set { mainWeaponCaliber = value; }
    }
    private double speed;
    public double Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }
    private List<string> targets = new List<string>();
    public ICollection<string> Targets => targets.AsReadOnly();
    protected int defaultArmor;
    public Vessel(string name,double mainWeaponCaliber,double speed,double armorThickness)
    {
        Name = name;
        MainWeaponCaliber = mainWeaponCaliber;
        Speed = speed;
        ArmorThickness = armorThickness;
    }
    public void Attack(IVessel target)
    {
        if(target == null)
        {
            throw new NullReferenceException("Target cannot be null.");
        }
        target.ArmorThickness -= MainWeaponCaliber;
        if(target.ArmorThickness < 0)
        {
            target.ArmorThickness = 0;
        }
        targets.Add(target.Name);
    }
    public void RepairVessel()
    {
        if(ArmorThickness < defaultArmor)
        {
            ArmorThickness = defaultArmor;
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"- {Name}");
        sb.AppendLine($"*Type: {GetType().Name}");
        sb.AppendLine($"*Armor thickness: {ArmorThickness}");
        sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
        sb.AppendLine($"*Speed: {Speed} knots");
        sb.Append($"*Targets: ");
        if(Targets.Any())
        {
            sb.Append(string.Join(", ",Targets));
        }
        else
        {
            sb.Append("None");
        }
        return sb.ToString();
    }
}
