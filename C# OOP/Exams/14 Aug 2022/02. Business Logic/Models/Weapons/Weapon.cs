using System;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon:IWeapon
    {
        private double price;
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }
        private int destructionLevel;
        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if(value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                destructionLevel = value;
            }
        }
        public Weapon(double price,int destructionLevel)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }
    }
}
