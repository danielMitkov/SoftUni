using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EasterRaces.Core.Entities
{
    public class ChampionshipController:IChampionshipController
    {
        private CarRepository cars = new CarRepository();
        private DriverRepository drivers = new DriverRepository();
        private RaceRepository races = new RaceRepository();
        public string AddCarToDriver(string name,string model)
        {
            IDriver driver = drivers.GetByName(name);
            if(driver == null)
            {
                throw new InvalidOperationException($"Driver {name} could not be found.");
            }
            ICar car = cars.GetByName(model);
            if(car == null)
            {
                throw new InvalidOperationException($"Car {name} could not be found.");
            }
            driver.AddCar(car);
            return $"Driver {driver.Name} received car {car.Model}.";
        }
        public string AddDriverToRace(string raceName,string driverName)
        {
            IRace race = races.GetByName(raceName);
            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IDriver driver = drivers.GetByName(driverName);
            if(driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            return $"Driver {driver.Name} added in {race.Name} race.";
        }
        public string CreateCar(string type,string model,int horsePower)
        {
            if(cars.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            ICar car = null;
            if(type == "Muscle")
            {
                car = new MuscleCar(model,horsePower);
            }
            else
            {
                car = new SportsCar(model,horsePower);
            }
            cars.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }
        public string CreateDriver(string name)
        {
            if(drivers.GetByName(name) != null)
            {
                throw new ArgumentException($"Driver {name} is already created.");
            }
            IDriver driver = new Driver(name);
            drivers.Add(driver);
            return $"Driver {name} is created.";
        }
        public string CreateRace(string name,int laps)
        {
            if(races.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            IRace race = new Race(name,laps);
            races.Add(race);
            return $"Race {name} is created.";
        }
        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);
            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            races.Remove(race);
            List<IDriver> winners = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {winners[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {winners[1].Name} is second in {raceName} race.");
            sb.Append($"Driver {winners[2].Name} is third in {raceName} race.");
            return sb.ToString();
        }
    }
}
