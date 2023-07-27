using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace SpaceStation.Models.Mission
{
    public class Mission:IMission
    {
        public void Explore(IPlanet planet,ICollection<IAstronaut> astronauts)
        {
            foreach(IAstronaut astronaut in astronauts.Where(x=>x.CanBreath))
            {
                while(astronaut.CanBreath)
                {
                    astronaut.Bag.Items.Add(planet.Items.ToList()[0]);
                    planet.Items.ToList().RemoveAt(0);
                    astronaut.Breath();
                }
            }
        }
    }
}
