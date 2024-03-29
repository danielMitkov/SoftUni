﻿using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CarRacing.Repositories
{
    public class RacerRepository:IRepository<IRacer>
    {
        private List<IRacer> models = new List<IRacer>();
        public IReadOnlyCollection<IRacer> Models => models.AsReadOnly();
        public void Add(IRacer model)
        {
            if(model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }
            models.Add(model);
        }
        public IRacer FindBy(string property) => models.FirstOrDefault(x => x.Username == property);
        public bool Remove(IRacer model) => models.Remove(model);
    }
}
