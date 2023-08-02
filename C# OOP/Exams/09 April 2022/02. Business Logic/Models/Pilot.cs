using Formula1.Models.Contracts;
using System;
namespace Formula1.Models
{
    public class Pilot:IPilot
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                fullName = value;
            }
        }
        private IFormulaOneCar car;
        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if(value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                car = value;
            }
        }
        private int numberOfWins;
        public int NumberOfWins
        {
            get { return numberOfWins; }
            private set { numberOfWins = value; }
        }
        private bool canRace;
        public bool CanRace
        {
            get { return canRace; }
            private set { canRace = value; }
        }
        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
        }
        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }
        public void WinRace() => NumberOfWins++;
        public override string ToString() => $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}
