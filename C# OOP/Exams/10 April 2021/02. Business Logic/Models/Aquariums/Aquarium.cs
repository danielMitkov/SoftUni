using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium:IAquarium
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        private List<IDecoration> decorations = new List<IDecoration>();
        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();
        private List<IFish> fish = new List<IFish>();
        public ICollection<IFish> Fish => fish.AsReadOnly();
        public int Comfort => Decorations.Sum(x => x.Comfort);
        public Aquarium(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public void AddDecoration(IDecoration decoration) => decorations.Add(decoration);
        public void AddFish(IFish fish)
        {
            if(this.fish.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.fish.Add(fish);
        }
        public void Feed()
        {
            foreach(IFish fish in fish)
            {
                fish.Eat();
            }
        }
        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({GetType().Name}):");
            sb.Append("Fish: ");
            if(fish.Any())
            {
                sb.AppendLine(string.Join(", ",fish.Select(x => x.Name)));
            }
            else
            {
                sb.AppendLine("none");
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.Append($"Comfort: {Comfort}");
            return sb.ToString();
        }
        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);
    }
}
