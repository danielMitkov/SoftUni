using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
namespace NavalVessels.Models;
public class Captain:ICaptain
{
    private string fullName;
    public string FullName
    {
        get { return fullName; }
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Captain full name cannot be null or empty string.");
            }
            fullName = value;
        }
    }
    private int combatExperience;
    public int CombatExperience
    {
        get { return combatExperience; }
        private set { combatExperience = value; }
    }
    private List<IVessel> vessels = new();
    public ICollection<IVessel> Vessels => vessels.AsReadOnly();
    public Captain(string fullName)
    {
        FullName = fullName;
    }
    public void AddVessel(IVessel vessel)
    {
        if(vessel == null)
        {
            throw new NullReferenceException("Null vessel cannot be added to the captain.");
        }
        vessels.Add(vessel);
    }
    public void IncreaseCombatExperience()
    {
        CombatExperience += 10;
    }
    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
        foreach(IVessel vessel in vessels)
        {
            sb.AppendLine(vessel.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
