using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
namespace SpaceStation.Models.Planets
{
    public class Planet:IPlanet
    {
        private List<string> items = new List<string>();
        public ICollection<string> Items => items;
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }
        public Planet(string name)
        {
            Name = name;
        }
    }
}
