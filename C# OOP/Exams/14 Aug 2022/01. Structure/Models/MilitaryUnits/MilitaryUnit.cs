using System;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit:IMilitaryUnit
    {
        private double cost;
        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }
        private int enduranceLevel;
        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set { enduranceLevel = value; }
        }
        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }
        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if(EnduranceLevel > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
