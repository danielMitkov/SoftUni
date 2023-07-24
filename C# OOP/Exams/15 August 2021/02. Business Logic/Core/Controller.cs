using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using System;
using System.Linq;
using System.Text;
namespace CarRacing.Core
{
    public class Controller:IController
    {
        private IRepository<ICar> cars = new CarRepository();
        private IRepository<IRacer> racers = new RacerRepository();
        private IMap map = new Map();
        public string AddCar(string type,string make,string model,string VIN,int horsePower)
        {
            if(type != nameof(SuperCar) && type != nameof(TunedCar))
            {
                throw new ArgumentException("Invalid car type!");
            }
            ICar car = null;
            if(type == nameof(SuperCar))
            {
                car = new SuperCar(make,model,VIN,horsePower);
            }
            else
            {
                car = new TunedCar(make,model,VIN,horsePower);
            }
            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }
        public string AddRacer(string type,string username,string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            if(car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            if(type != nameof(ProfessionalRacer) && type != nameof(StreetRacer))
            {
                throw new ArgumentException("Invalid racer type!");
            }
            IRacer racer = null;
            if(type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username,car);
            }
            else
            {
                racer = new StreetRacer(username,car);
            }
            racers.Add(racer);
            return $"Successfully added racer {username}.";
        }
        public string BeginRace(string racerOneUsername,string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            if(racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            IRacer racerTwo = racers.FindBy(racerTwoUsername);
            if(racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            return map.StartRace(racerOne,racerTwo);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IRacer racer in racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
