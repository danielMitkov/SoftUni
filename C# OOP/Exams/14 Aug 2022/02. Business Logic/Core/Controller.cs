using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;
namespace PlanetWars.Core
{
    public class Controller:IController
    {
        PlanetRepository planets = new PlanetRepository();
        public string AddUnit(string unitTypeName,string planetName)
        {
            if(planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .UnexistingPlanet,planetName));
            }
            if(unitTypeName != "AnonymousImpactUnit"
                && unitTypeName != "SpaceForces"
                && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .ItemNotAvailable,unitTypeName));
            }
            IPlanet planet = planets.FindByName(planetName);
            if(planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .UnitAlreadyAdded,unitTypeName,planetName));
            }
            IMilitaryUnit unit = null;
            if(unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            if(unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            if(unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded,unitTypeName,planetName);
        }
        public string AddWeapon(string planetName,string weaponTypeName,int destructionLevel)
        {
            if(planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .UnexistingPlanet,planetName));
            }
            IPlanet planet = planets.FindByName(planetName);
            if(planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .WeaponAlreadyAdded,weaponTypeName,planetName));
            }
            if(weaponTypeName != "BioChemicalWeapon"
                && weaponTypeName != "NuclearWeapon"
                && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .ItemNotAvailable,weaponTypeName));
            }
            IWeapon weapon = null;
            if(weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            if(weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            if(weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded,planetName,weaponTypeName);
        }
        public string CreatePlanet(string name,double budget)
        {
            if(planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet,name);
            }
            Planet planet = new Planet(name,budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet,name);
        }
        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach(IPlanet planet in planets.Models
                .OrderByDescending(x=>x.MilitaryPower)
                .ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }
        public string SpaceCombat(string planetOne,string planetTwo)
        {
            IPlanet planetFirst = planets.FindByName(planetOne);
            IPlanet planetSecond = planets.FindByName(planetTwo);
            IPlanet winner = null;
            IPlanet loser = null;
            if(planetFirst.MilitaryPower > planetSecond.MilitaryPower)
            {
                winner = planetFirst;
                loser = planetSecond;
            }
            else if(planetFirst.MilitaryPower < planetSecond.MilitaryPower)
            {
                winner = planetSecond;
                loser = planetFirst;
            }
            else if(planetFirst.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                && !planetSecond.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                winner = planetFirst;
                loser = planetSecond;
            }
            else if(!planetFirst.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                && planetSecond.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                winner = planetSecond;
                loser = planetFirst;
            }
            else
            {
                planetFirst.Spend(planetFirst.Budget / 2);
                planetSecond.Spend(planetSecond.Budget / 2);
                return OutputMessages.NoWinner;
            }
            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            double sumCosts = loser.Army.Sum(x => x.Cost);
            double sumPrices = loser.Weapons.Sum(x => x.Price);
            double totalSum = sumCosts + sumPrices;
            winner.Profit(totalSum);
            planets.RemoveItem(loser.Name);
            return string.Format(OutputMessages.WinnigTheWar,winner.Name,loser.Name);
        }
        public string SpecializeForces(string planetName)
        {
            if(planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages
                    .UnexistingPlanet,planetName));
            }
            IPlanet planet = planets.FindByName(planetName);
            if(planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded,planetName);
        }
    }
}
