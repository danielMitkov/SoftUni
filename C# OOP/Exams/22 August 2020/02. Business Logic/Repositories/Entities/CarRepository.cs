﻿using EasterRaces.Models.Cars.Contracts;
using System.Linq;
namespace EasterRaces.Repositories.Entities
{
    public class CarRepository:Repository<ICar>
    {
        public override ICar GetByName(string name) => GetAll().FirstOrDefault(x => x.Model == name);
    }
}
