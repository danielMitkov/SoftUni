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
        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }
        public IPlanet FindByName(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
        public bool RemoveItem(string type)
        {
            IPlanet weapon = models.FirstOrDefault(x => x.GetType().Name == type);
            if(weapon != null)
            {
                return models.Remove(weapon);
            }
            return false;
        }
    }
}
