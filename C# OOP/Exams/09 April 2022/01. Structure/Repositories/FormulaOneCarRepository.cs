using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace Formula1.Repositories
{
    public class FormulaOneCarRepository:IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models = new();
        public IReadOnlyCollection<IFormulaOneCar> Models => models.AsReadOnly();
        public void Add(IFormulaOneCar model) => models.Add(model);
        public IFormulaOneCar FindByName(string name) => models.FirstOrDefault(x=>x.Model == name);
        public bool Remove(IFormulaOneCar model) => models.Remove(model);
    }
}
