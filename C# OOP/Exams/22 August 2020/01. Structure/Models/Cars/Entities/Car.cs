using EasterRaces.Models.Cars.Contracts;
using System;
namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car:ICar
    {
        private int minHorsePower;
        private int maxHorsePower;
        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }
        private int horsePower;
        public virtual int HorsePower
        {
            get { return horsePower; }
            private set
            {
                if(value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
        private double cubicCentimeters;
        public double CubicCentimeters
        {
            get { return cubicCentimeters; }
            private set { cubicCentimeters = value; }
        }
        public Car(string model,int horsePower,double cubicCentimeters,int minHorsePower,int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
        }
        public double CalculateRacePoints(int laps) => CubicCentimeters / HorsePower * laps;
    }
}
