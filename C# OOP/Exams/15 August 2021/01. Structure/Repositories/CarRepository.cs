using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CarRacing.Repositories
{
    public class CarRepository:IRepository<ICar>
    {
        private List<ICar> models = new List<ICar>();
        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();
        public void Add(ICar model)
        {
            if(model == null)
            {
                throw new ArgumentException("Cannot add null in Car Repository");
            }
            models.Add(model);
        }
        public ICar FindBy(string property) => models.FirstOrDefault(x => x.VIN == property);
        public bool Remove(ICar model) => models.Remove(model);
    }
}
