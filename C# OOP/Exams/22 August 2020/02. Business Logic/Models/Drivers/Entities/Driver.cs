using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver:IDriver
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }
        private ICar car;
        public ICar Car
        {
            get { return car; }
            private set { car = value; }
        }
        private int numberOfWins;
        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }
        private bool canParticipate = false;
        public bool CanParticipate
        {
            get { return canParticipate; }
            private set { canParticipate = value; }
        }
        public Driver(string name)
        {
            Name = name;
        }
        public void AddCar(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentNullException("Car cannot be null.");
            }
            Car = car;
            CanParticipate = true;
        }
        public void WinRace() => NumberOfWins++;
    }
}
