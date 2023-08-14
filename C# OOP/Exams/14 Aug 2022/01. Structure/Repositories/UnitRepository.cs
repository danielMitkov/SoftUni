using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace PlanetWars.Repositories
{
    public class UnitRepository:IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models = new List<IMilitaryUnit>();
        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();
        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }
        public IMilitaryUnit FindByName(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
        public bool RemoveItem(string type)
        {
            IMilitaryUnit weapon = models.FirstOrDefault(x => x.GetType().Name == type);
            if(weapon != null)
            {
                return models.Remove(weapon);
            }
            return false;
        }
    }
}
