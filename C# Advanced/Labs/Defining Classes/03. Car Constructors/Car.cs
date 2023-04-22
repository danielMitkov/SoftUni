using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer {
    public class Car {
        public Car() {
            Make="VW";
            Model="Golf";
            Year=2025;
            FuelQuantity=200;
            FuelConsumption=10;
        }
        public Car(string make,string model,int year) : this() {
            this.make=make;
            this.model=model;
            this.year=year;
        }

        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption) 
            : this(make,model,year) {
            this.fuelQuantity=fuelQuantity;
            this.fuelConsumption=fuelConsumption;
        }
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get => make; set => make=value; }
        public string Model { get => model; set => model=value; }
        public int Year { get => year; set => year=value; }
        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity=value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption=value; }
    }
}