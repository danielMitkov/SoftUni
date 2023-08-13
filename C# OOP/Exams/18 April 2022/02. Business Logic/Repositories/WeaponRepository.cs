using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
namespace Heroes.Repositories
{
    public class WeaponRepository:IRepository<IWeapon>
    {
        private List<IWeapon> models = new List<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models => models.AsReadOnly();
        public void Add(IWeapon model) => models.Add(model);
        public IWeapon FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
        public bool Remove(IWeapon model) => models.Remove(model);
    }
}
