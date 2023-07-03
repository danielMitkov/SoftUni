using ExplicitInterfaces.INames;
namespace ExplicitInterfaces;
public class Citizen:IResident, IPerson
{
    public string Name { get; private set; }
    public string Country { get; private set; }
    public int Age { get; private set; }
    public Citizen(string name,string country,int age)
    {
        Name = name;
        Country = country;
        Age = age;
    }
    string IResident.GetName() => $"Mr/Ms/Mrs {Name}";
    string IPerson.GetName() => Name;
}