using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
namespace EasterRaces.Models.Races.Entities
{
    public class Race:IRace
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }
        private int laps;
        public int Laps
        {
            get { return laps; }
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                laps = value;
            }
        }
        private List<IDriver> drivers = new List<IDriver>();
        public IReadOnlyCollection<IDriver> Drivers => drivers.AsReadOnly();
        public Race(string name,int laps)
        {
            Name = name;
            Laps = laps;
        }
        public void AddDriver(IDriver driver)
        {
            if(driver == null)
            {
                throw new ArgumentNullException("Driver cannot be null.");
            }
            if(driver.CanParticipate == false)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }
            if(drivers.Contains(driver))
            {
                throw new ArgumentNullException($"Driver {driver.Name} is already added in {Name} race.");
            }
            drivers.Add(driver);
        }
    }
}
