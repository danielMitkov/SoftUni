using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut:IAstronaut
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }
        private double oxygen;
        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }
        private bool canBreath;
        public bool CanBreath
        {
            get => Oxygen > 0;
        }
        private IBag bag = new Backpack();
        public IBag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }
        public Astronaut(string name,double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
        }
        public virtual void Breath()
        {
            if(Oxygen - 10 < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 10;
            }
        }
    }
}
