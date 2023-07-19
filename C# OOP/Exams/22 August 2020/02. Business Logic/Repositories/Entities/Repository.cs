using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T>:IRepository<T>
    {
        private List<T> models = new List<T>();
        public void Add(T model) => models.Add(model);
        public IReadOnlyCollection<T> GetAll() => models.AsReadOnly();
        public abstract T GetByName(string name);
        public bool Remove(T model) => models.Remove(model);
    }
}
