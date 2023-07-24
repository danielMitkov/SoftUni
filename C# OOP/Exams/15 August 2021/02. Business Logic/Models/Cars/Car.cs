using CarRacing.Models.Cars.Contracts;
using System;
namespace CarRacing.Models.Cars
{
    public abstract class Car:ICar
    {
        private string make;
        public string Make
        {
            get { return make; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                make = value;
            }
        }
        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                model = value;
            }
        }
        private string vin;
        public string VIN
        {
            get { return vin; }
            private set
            {
                if(value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                vin = value;
            }
        }
        private int horsePower;
        public int HorsePower
        {
            get { return horsePower; }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                horsePower = value;
            }
        }
        private double fuelAvailable;
        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set
            {
                if(value < 0)
                {
                    fuelAvailable = 0;
                }
                else
                {
                    fuelAvailable = value;
                }
            }
        }
        private double fuelConsumptionPerRace;
        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                fuelConsumptionPerRace = value;
            }
        }
        public Car(string make,string model,string VIN,int horsePower,double fuelAvailable,double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }
        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
