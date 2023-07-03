namespace PersonInfo;
public class Citizen:IPerson, IIdentifiable, IBirthable
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Id { get; init; }
    public string Birthdate { get; init; }
    public Citizen(string name,int age,string id,string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }
}