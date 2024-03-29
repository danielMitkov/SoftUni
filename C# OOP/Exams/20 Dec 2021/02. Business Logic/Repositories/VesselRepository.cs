﻿using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace NavalVessels.Repositories;
public class VesselRepository:IRepository<IVessel>
{
    private List<IVessel> models = new();
    public IReadOnlyCollection<IVessel> Models => models.AsReadOnly();
    public void Add(IVessel model) => models.Add(model);
    public IVessel FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
    public bool Remove(IVessel model) => models.Remove(model);
}
