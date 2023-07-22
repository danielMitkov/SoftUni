using AquaShop.Models.Fish.Contracts;
using System;
namespace AquaShop.Models.Fish
{
    public abstract class Fish:IFish
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }
                name = value;
            }
        }
        private string species;
        public string Species
        {
            get { return species; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }
                species = value;
            }
        }
        private int size;
        public int Size
        {
            get { return size; }
            protected set { size = value; }
        }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                price = value;
            }
        }
        public Fish(string name,string species,decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }
        public abstract void Eat();
    }
}
