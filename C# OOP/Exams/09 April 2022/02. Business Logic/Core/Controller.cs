using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Formula1.Core;
public class Controller:IController
{
    private IRepository<IPilot> pilotRepository = new PilotRepository();
    private IRepository<IRace> raceRepository = new RaceRepository();
    private IRepository<IFormulaOneCar> carRepository = new FormulaOneCarRepository();
    public string AddCarToPilot(string pilotName,string carModel)
    {
        IPilot pilot = pilotRepository.FindByName(pilotName);
        if(pilot == null || pilot.Car != null)
        {
            throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
        }
        IFormulaOneCar car = carRepository.FindByName(carModel);
        if(car == null)
        {
            throw new NullReferenceException($"Car {carModel} does not exist.");
        }
        pilot.AddCar(car);
        carRepository.Remove(car);
        return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
    }
    public string AddPilotToRace(string raceName,string pilotFullName)
    {
        IRace race = raceRepository.FindByName(raceName);
        if(race == null)
        {
            throw new NullReferenceException($"Race {raceName} does not exist.");
        }
        IPilot pilot = pilotRepository.FindByName(pilotFullName);
        if(pilot == null || pilot.CanRace == false || race.Pilots.Any(x => x.FullName == pilotFullName))
        {
            throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
        }
        race.AddPilot(pilot);
        return $"Pilot {pilotFullName} is added to the {raceName} race.";
    }
    public string CreateCar(string type,string model,int horsepower,double engineDisplacement)
    {
        if(carRepository.FindByName(model) != null)
        {
            throw new InvalidOperationException($"Formula one car {model} is already created.");
        }
        if(type != nameof(Ferrari) && type != nameof(Williams))
        {
            throw new InvalidOperationException($"Formula one car type {type} is not valid.");
        }
        IFormulaOneCar car = null;
        if(type == nameof(Ferrari))
        {
            car = new Ferrari(model,horsepower,engineDisplacement);
        }
        if(type == nameof(Williams))
        {
            car = new Williams(model,horsepower,engineDisplacement);
        }
        carRepository.Add(car);
        return $"Car {type}, model {model} is created.";
    }
    public string CreatePilot(string fullName)
    {
        if(pilotRepository.FindByName(fullName) != null)
        {
            throw new InvalidOperationException($"Pilot {fullName} is already created.");
        }
        IPilot pilot = new Pilot(fullName);
        pilotRepository.Add(pilot);
        return $"Pilot {fullName} is created.";
    }
    public string CreateRace(string raceName,int numberOfLaps)
    {
        if(raceRepository.FindByName(raceName) != null)
        {
            throw new InvalidOperationException($"Race {raceName} is already created.");
        }
        IRace race = new Race(raceName,numberOfLaps);
        raceRepository.Add(race);
        return $"Race {raceName} is created.";
    }
    public string PilotReport()
    {
        StringBuilder sb = new StringBuilder();
        foreach(IPilot pilot in pilotRepository.Models.OrderByDescending(x=>x.NumberOfWins))
        {
            sb.AppendLine(pilot.ToString());
        }
        return sb.ToString().TrimEnd();
    }
    public string RaceReport()
    {
        StringBuilder sb = new StringBuilder();
        foreach(IRace race in raceRepository.Models.Where(x=>x.TookPlace == true))
        {
            sb.AppendLine(race.RaceInfo());
        }
        return sb.ToString().TrimEnd();
    }
    public string StartRace(string raceName)
    {
        IRace race = raceRepository.FindByName(raceName);
        if(race == null)
        {
            throw new NullReferenceException($"Race {raceName} does not exist.");
        }
        if(race.Pilots.Count < 3)
        {
            throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
        }
        if(race.TookPlace)
        {
            throw new InvalidOperationException($"Can not execute race {raceName}.");
        }
        List<IPilot> pilots = race.Pilots
            .OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
        race.TookPlace = true;
        pilots.First().WinRace();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Pilot {pilots[0].FullName} wins the {raceName} race.");
        sb.AppendLine($"Pilot {pilots[1].FullName} is second in the {raceName} race.");
        sb.Append($"Pilot {pilots[2].FullName} is third in the {raceName} race.");
        return sb.ToString();
    }
}
