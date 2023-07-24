using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
namespace CarRacing.Models.Racers
{
    public abstract class Racer:IRacer
    {
        private string username;
        public string Username
        {
            get { return username; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                username = value;
            }
        }
        private string racingBehavior;
        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Racing behavior cannot be null or empty.");
                }
                racingBehavior = value;
            }
        }
        private int drivingExperience;
        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("Racer driving experience must be between 0 and 100.");
                }
                drivingExperience = value;
            }
        }
        private ICar car;
        public ICar Car
        {
            get { return car; }
            private set
            {
                if(value == null)
                {
                    throw new ArgumentException("Car cannot be null or empty.");
                }
                car = value;
            }
        }
        public Racer(string username,string racingBehavior,int drivingExperience,ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }
        public bool IsAvailable()
        {
            if(Car.FuelAvailable - Car.FuelConsumptionPerRace >= 0)
            {
                return true;
            }
            return false;
        }
        public virtual void Race()
        {
            Car.Drive();
        }
    }
}
