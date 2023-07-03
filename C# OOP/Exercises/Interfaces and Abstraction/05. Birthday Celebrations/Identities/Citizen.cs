using BirthdayCelebrations.Interfaces;
namespace BirthdayCelebrations.Identities;
public class Citizen:Identity, IBirthdate
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Birthdate { get; init; }
    public Citizen(string name,int age,string id,string birthDate) : base(id)
    {
        Name = name;
        Age = age;
        Birthdate = birthDate;
    }
}