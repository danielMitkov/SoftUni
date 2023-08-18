using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail:ICocktail
    {
        private string name;
        private string size;
        private double price;
        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public string Size { get => size; private set => size = value; }
        public double Price
        {
            get => price;
            private set
            {
                if(Size == "Large")
                {
                    price = value;
                }
                if(Size == "Middle")
                {
                    price = value / 3 * 2;
                }
                if(Size == "Large")
                {
                    price = value / 3;
                }
            }
        }
        protected Cocktail(string name,string size,double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }
        public override string ToString() => $"{Name} ({Size}) - {Price} lv";
    }
}