﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace PlanetWars.Repositories
{
    public class UnitRepository:IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models = new List<IMilitaryUnit>();
        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();
        public void AddItem(IMilitaryUnit unit)
        {
            models.Add(unit);
        }
        public IMilitaryUnit FindByName(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
        public bool RemoveItem(string type)
        {
            IMilitaryUnit unit = models.FirstOrDefault(x => x.GetType().Name == type);
            if(unit != null)
            {
                return models.Remove(unit);
            }
            return false;
        }
    }
}
