using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace PlanetWars.Repositories
{
    public class WeaponRepository:IRepository<IWeapon>
    {
        private List<IWeapon> models = new List<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();
        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }
        public IWeapon FindByName(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
        public bool RemoveItem(string type)
        {
            IWeapon weapon = models.FirstOrDefault(x=>x.GetType().Name == type);
            if(weapon != null)
            {
                return models.Remove(weapon);
            }
            return false;
        }
    }
}
