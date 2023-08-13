using System;
using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.WeaponTypeNull);
                }
                name = value;
            }
        }
        private int durability;
        public int Durability
        {
            get { return durability; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurabilityBelowZero);
                }
                durability = value;
            }
        }
        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
        public abstract int DoDamage();
    }
}
