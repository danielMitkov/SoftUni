using Bakery.Models.BakedFoods.Contracts;
using System;
namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood:IBakedFood
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                name = value;
            }
        }
        private int portion;
        public int Portion
        {
            get { return portion; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Portion cannot be less or equal to zero");
                }
                portion = value;
            }
        }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                price = value;
            }
        }
        public BakedFood(string name,int portion,decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }
        public override string ToString() => $"{Name}: {Portion}g - {Price:F2}";
    }
}
