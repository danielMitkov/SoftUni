using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Models.Vessels;
using NavalVessels.Repositories;
using System.Collections.Generic;
using System.Linq;
namespace NavalVessels.Core;
public class Controller:IController
{
    private VesselRepository vessels = new VesselRepository();
    private List<ICaptain> captains = new List<ICaptain>();
    public string AssignCaptain(string captainName,string vesselName)
    {
        ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainName);
        if(captain == null)
        {
            return $"Captain {captainName} could not be found.";
        }
        IVessel vessel = vessels.FindByName(vesselName);
        if(vessel == null)
        {
            return $"Vessel {vesselName} could not be found.";
        }
        if(vessel.Captain != null)
        {
            return $"Vessel {vesselName} is already occupied.";
        }
        vessel.Captain = captain;
        captain.AddVessel(vessel);
        return $"Captain {captainName} command vessel {vesselName}.";
    }
    public string AttackVessels(string attackerName,string defenderName)
    {
        IVessel attacker = vessels.FindByName(attackerName);
        if(attacker == null)
        {
            return $"Vessel {attackerName} could not be found.";
        }
        IVessel defender = vessels.FindByName(defenderName);
        if(defender == null)
        {
            return $"Vessel {defenderName} could not be found.";
        }
        if(attacker.ArmorThickness == 0)
        {
            return $"Unarmored vessel {attackerName} cannot attack or be attacked.";
        }
        if(defender.ArmorThickness == 0)
        {
            return $"Unarmored vessel {defenderName} cannot attack or be attacked.";
        }
        attacker.Attack(defender);
        attacker.Captain.IncreaseCombatExperience();
        defender.Captain.IncreaseCombatExperience();
        return $"Vessel {defenderName} was attacked by vessel {attackerName} - current armor thickness: {defender.ArmorThickness}.";
    }
    public string CaptainReport(string captainFullName)
    {
        IVessel vessel = vessels.Models.First(x => x.Captain.FullName == captainFullName);
        return vessel.Captain.Report();
    }
    public string HireCaptain(string fullName)
    {
        if(captains.Any(x => x.FullName == fullName))
        {
            return $"Captain {fullName} is already hired.";
        }
        ICaptain captain = new Captain(fullName);
        captains.Add(captain);
        return $"Captain {fullName} is hired.";
    }
    public string ProduceVessel(string name,string type,double mainWeaponCaliber,double speed)
    {
        if(vessels.FindByName(name) != null)
        {
            return $"{type} vessel {name} is already manufactured.";
        }
        if(type != nameof(Battleship) && type != nameof(Submarine))
        {
            return "Invalid vessel type.";
        }
        IVessel vessel = null;
        if(type == nameof(Battleship))
        {
            vessel = new Battleship(name,mainWeaponCaliber,speed);
        }
        else
        {
            vessel = new Submarine(name,mainWeaponCaliber,speed);
        }
        vessels.Add(vessel);
        return $"{type} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
    }
    public string ServiceVessel(string name)
    {
        IVessel vessel = vessels.FindByName(name);
        if(vessel == null)
        {
            return $"Vessel {name} could not be found.";
        }
        vessel.RepairVessel();
        return $"Vessel {name} was repaired.";
    }
    public string ToggleSpecialMode(string vesselName)
    {
        IVessel vessel = vessels.FindByName(vesselName);
        if(vessel == null)
        {
            return $"Vessel {vesselName} could not be found.";
        }
        if(vessel is Battleship battleShip)
        {
            battleShip.ToggleSonarMode();
            return $"Battleship {vesselName} toggled sonar mode.";
        }
        ((Submarine)vessel).ToggleSubmergeMode();
        return $"Submarine {vesselName} toggled submerge mode.";
    }
    public string VesselReport(string vesselName)
    {
        IVessel vessel = vessels.FindByName(vesselName);
        return vessel.ToString();
    }
}
