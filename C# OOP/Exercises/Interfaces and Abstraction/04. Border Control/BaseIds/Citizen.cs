namespace BorderControl.BaseIds;
public class Citizen : BaseId
{
    public string Name { get; init; }
    public int Age { get; init; }
    public Citizen(string name, int age, string id) : base(id)
    {
        Name = name;
        Age = age;
    }
}