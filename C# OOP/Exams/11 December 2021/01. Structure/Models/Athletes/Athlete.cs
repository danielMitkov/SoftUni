using Gym.Models.Athletes.Contracts;
using System;
namespace Gym.Models.Athletes
{
    public abstract class Athlete:IAthlete
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }
                fullName = value;
            }
        }
        private string motivation;
        public string Motivation
        {
            get { return motivation; }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }
                motivation = value;
            }
        }
        private int stamina;
        public int Stamina
        {
            get { return stamina; }
            protected set { stamina = value; }
        }
        private int numberOfMedals;
        public int NumberOfMedals
        {
            get { return numberOfMedals; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }
                numberOfMedals = value;
            }
        }
        public Athlete(string fullName,string motivation,int numberOfMedals,int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }
        public abstract void Exercise();
    }
}
