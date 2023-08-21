using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;
namespace UniversityCompetition.Repositories;
public class StudentRepository:IRepository<IStudent>
{
    private List<IStudent> students = new();
    public IReadOnlyCollection<IStudent> Models => students.AsReadOnly();
    public void AddModel(IStudent model) => students.Add(model);
    public IStudent FindById(int id) => students.FirstOrDefault(x => x.Id == id);
    public IStudent FindByName(string name)
    {
        string[] fullName = name.Split(' ');
        string firstName = fullName[0];
        string lastName = fullName[1];
        return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}