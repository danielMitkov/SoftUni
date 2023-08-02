using Formula1.Models.Contracts;
using System;
namespace Formula1.Models
{
    public abstract class FormulaOneCar:IFormulaOneCar
    {
        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException($"Invalid car model: {value}.");
                }
                model = value;
            }
        }
        private int horsepower;
        public int Horsepower
        {
            get { return horsepower; }
            private set
            {
                if(value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: {value}.");
                }
                horsepower = value;
            }
        }
        private double engineDisplacement;
        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                if(value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: {value}.");
                }
                engineDisplacement = value;
            }
        }
        public FormulaOneCar(string model,int horsepower,double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }
        public double RaceScoreCalculator(int laps) => EngineDisplacement / Horsepower * laps;
    }
}
