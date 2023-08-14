using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
namespace PlanetWars.Models.Planets
{
    public class Planet:IPlanet
    {
        UnitRepository units = new UnitRepository();
        WeaponRepository weapons = new WeaponRepository();
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }
        private double budget;
        public double Budget
        {
            get { return budget; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }
        public double MilitaryPower
        {
            get
            {
                int sumUndurences = units.Models.Sum(x => x.EnduranceLevel);
                int sumDestructionLevels = weapons.Models.Sum(x => x.DestructionLevel);
                double total = sumUndurences + sumDestructionLevels;
                if(units.Models.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                {
                    total += total * 0.3;
                }
                if(weapons.Models.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    total += total * 0.45;
                }
                return Math.Round(total,3);
            }
        }
        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;
        public Planet(string name,double budget)
        {
            Name = name;
            Budget = budget;
        }
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }
        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append($"--Forces: ");
            if(units.Models.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                sb.AppendLine($"{string.Join(", ",units.Models.Select(x => x.GetType().Name))}");
            }
            sb.AppendLine($"--Combat equipment: ");
            if(weapons.Models.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                sb.AppendLine($"{string.Join(", ",weapons.Models.Select(x => x.GetType().Name))}");
            }
            sb.Append($"--Military Power: {MilitaryPower}");
            return sb.ToString();
        }
        public void Profit(double amount)
        {
            Budget += amount;
        }
        public void Spend(double amount)
        {
            if(amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }
        public void TrainArmy()
        {
            foreach(IMilitaryUnit unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
