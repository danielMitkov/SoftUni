﻿using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy:IDelicacy
    {
        private string name;
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
        public double Price { get => price; private set => price = value; }
        protected Delicacy(string name,double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString() => $"{Name} - {Price:F2} lv";
    }
}