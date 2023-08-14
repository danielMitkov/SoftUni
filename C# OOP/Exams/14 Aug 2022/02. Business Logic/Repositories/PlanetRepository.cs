using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace PlanetWars.Repositories
{
    public class PlanetRepository:IRepository<IPlanet>
    {
        private List<IPlanet> models = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();
        public void AddItem(IPlanet planet)
        {
            models.Add(planet);
        }
        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
        public bool RemoveItem(string name)
        {
            IPlanet planet = models.FirstOrDefault(x => x.Name == name);
            if(planet != null)
            {
                return models.Remove(planet);
            }
            return false;
        }
    }
}
