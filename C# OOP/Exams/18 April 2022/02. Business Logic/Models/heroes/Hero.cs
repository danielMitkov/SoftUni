using System;
using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
namespace Heroes.Models
{
    public class Hero:IHero
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }
                name = value;
            }
        }
        private int health;
        public int Health
        {
            get { return health; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }
                health = value;
            }
        }
        private int armour;
        public int Armour
        {
            get { return armour; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }
                armour = value;
            }
        }
        private IWeapon weapon;
        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if(value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }
                weapon = value;
            }
        }
        public bool IsAlive => Health > 0;
        public Hero(string name,int health,int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }
        public void AddWeapon(IWeapon weapon)
        {
            if(Weapon == null)
            {
                Weapon = weapon;
            }
        }
        public void TakeDamage(int points)
        {
            armour -= points;//bypassing pesky validations
            if(armour < 0)
            {
                health -= Math.Abs(armour);
                armour = 0;
                if(health < 0)
                {
                    health = 0;
                }
            }
        }
    }
}
