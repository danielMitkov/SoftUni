using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
namespace Heroes.Repositories
{
    public class HeroRepository:IRepository<IHero>
    {
        private List<IHero> models = new List<IHero>();
        public IReadOnlyCollection<IHero> Models => models.AsReadOnly();
        public void Add(IHero model) => models.Add(model);
        public IHero FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
        public bool Remove(IHero model) => models.Remove(model);
    }
}
