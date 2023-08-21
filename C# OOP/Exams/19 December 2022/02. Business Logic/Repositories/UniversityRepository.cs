using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;
namespace UniversityCompetition.Repositories;
public class UniversityRepository:IRepository<IUniversity>
{
    private List<IUniversity> universities = new();
    public IReadOnlyCollection<IUniversity> Models => universities.AsReadOnly();
    public void AddModel(IUniversity model) => universities.Add(model);
    public IUniversity FindById(int id) => universities.FirstOrDefault(x => x.Id == id);
    public IUniversity FindByName(string name) => universities.FirstOrDefault(x => x.Name == name);
}