using BirthdayCelebrations.Interfaces;
namespace BirthdayCelebrations;
public abstract class Identity:IIdentity
{
    public string Id { get; init; }
    protected Identity(string id)
    {
        Id = id;
    }
}