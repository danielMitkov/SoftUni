using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;
namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        private double baseHealth;
        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }
        private double health;
        public double Health
        {
            get { return health; }
            set
            {
                if(value < 0)
                {
                    health = 0;
                }
                else if(value > baseHealth)
                {
                    health = baseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }
        private double baseArmor;
        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }
        private double armor;
        public double Armor
        {
            get { return armor; }
            private set
            {
                if(value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }
        private double abilityPoints;
        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }
        private Bag bag;
        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }
        private bool isAlive;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public Character(string name,double health,double armor,double abilityPoints,Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            IsAlive = true;
        }
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double reducedHitPoints = hitPoints - armor;
            armor -= hitPoints;
            if(armor < 0)
            {
                armor = 0;
                health -= reducedHitPoints;
                if(health <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
        public void EnsureAlive()
        {
            if(!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
