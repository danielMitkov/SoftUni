namespace ExplicitInterfaces.INames;
public interface IResident : IName
{
    public string Country { get; }
    public string GetName();
}