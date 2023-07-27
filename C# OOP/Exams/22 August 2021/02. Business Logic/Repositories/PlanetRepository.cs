using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
namespace SpaceStation.Repositories
{
    public class PlanetRepository:IRepository<IPlanet>
    {
        private List<IPlanet> models = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();
        public void Add(IPlanet model) => models.Add(model);
        public IPlanet FindByName(string name) => models.Find(x => x.Name == name);
        public bool Remove(IPlanet model) => models.Remove(model);
    }
}
