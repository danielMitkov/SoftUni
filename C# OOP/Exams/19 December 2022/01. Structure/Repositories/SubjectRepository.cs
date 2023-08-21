using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;
namespace UniversityCompetition.Repositories;
public class SubjectRepository:IRepository<ISubject>
{
    private List<ISubject> subjects = new();
    public IReadOnlyCollection<ISubject> Models => subjects.AsReadOnly();
    public void AddModel(ISubject model) => subjects.Add(model);
    public ISubject FindById(int id) => subjects.FirstOrDefault(x => x.Id == id);
    public ISubject FindByName(string name) => subjects.FirstOrDefault(x => x.Name == name);
}