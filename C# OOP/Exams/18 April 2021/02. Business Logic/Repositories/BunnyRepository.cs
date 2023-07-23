﻿using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace Easter.Repositories
{
    public class BunnyRepository:IRepository<IBunny>
    {
        private List<IBunny> bunnies = new List<IBunny>();
        public IReadOnlyCollection<IBunny> Models => bunnies.AsReadOnly();
        public void Add(IBunny model) => bunnies.Add(model);
        public IBunny FindByName(string name) => bunnies.FirstOrDefault(x => x.Name == name);
        public bool Remove(IBunny model) => bunnies.Remove(model);
    }
}
