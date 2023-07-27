using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller:IController
    {
        AstronautRepository astronauts = new AstronautRepository();
        PlanetRepository planets = new PlanetRepository();
        HashSet<string> explored = new HashSet<string>();
        public string AddAstronaut(string type,string astronautName)
        {
            if(type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            IAstronaut astronaut = null;
            if(type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            if(type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            if(type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }
        public string AddPlanet(string planetName,params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach(string item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }
        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitable = astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if(suitable.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }
            Mission mission = new Mission();
            IPlanet planet = planets.FindByName(planetName);
            mission.Explore(planet,suitable);
            explored.Add(planetName);
            int deadCount = suitable.Where(x=>!x.CanBreath).Count();
            return $"Planet: {planetName} was explored! Exploration finished with {deadCount} dead astronauts!";
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{explored.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach(IAstronaut astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");
                if(astronaut.Bag.Items.Any())
                {
                    sb.AppendLine(string.Join(", ",astronaut.Bag.Items));
                }
                else
                {
                    sb.AppendLine("none");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if(astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
