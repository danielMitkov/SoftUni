using Easter.Models.Eggs.Contracts;
using System;
namespace Easter.Models.Eggs
{
    public class Egg:IEgg
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                name = value;
            }
        }
        private int energyRequired;
        public int EnergyRequired
        {
            get { return energyRequired; }
            private set
            {
                if(value < 0)
                {
                    energyRequired = 0;
                }
                else
                {
                    energyRequired = value;
                }
            }
        }
        public Egg(string name,int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }
        public void GetColored()
        {
            EnergyRequired -= 10;
            if(EnergyRequired < 0)
            {
                EnergyRequired = 0;
            }
        }
        public bool IsDone() => EnergyRequired == 0;
    }
}
