using BirthdayCelebrations.Interfaces;
namespace BirthdayCelebrations;
public class Pet:IBirthdate
{
    public string Name { get; init; }
    public string Birthdate { get; init; }
    public Pet(string name,string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
}