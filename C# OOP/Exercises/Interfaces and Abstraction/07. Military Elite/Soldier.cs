namespace MilitaryElite;
public abstract class Soldier
{
    public string Id { get; protected set; }
    public string FullName { get; protected set; }
    protected Soldier(string id,string fullName)
    {
        Id = id;
        FullName = fullName;
    }
    public override string ToString() => $"Name: {FullName} Id: {Id}";
}