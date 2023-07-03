namespace ExplicitInterfaces.INames;
public interface IPerson : IName
{
    public int Age { get; }
    public string GetName();
}