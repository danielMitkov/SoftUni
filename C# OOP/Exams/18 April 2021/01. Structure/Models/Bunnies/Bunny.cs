using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
namespace Easter.Models.Bunnies
{
    public abstract class Bunny:IBunny
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bunny name cannot be null or empty.");
                }
                name = value;
            }
        }
        private int energy;
        public int Energy
        {
            get { return energy; }
            protected set
            {
                if(value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }
        private List<IDye> dyes = new List<IDye>();
        public ICollection<IDye> Dyes => dyes.AsReadOnly();
        public Bunny(string name,int energy)
        {
            Name = name;
            Energy = energy;
        }
        public void AddDye(IDye dye) => dyes.Add(dye);
        public abstract void Work();
    }
}
