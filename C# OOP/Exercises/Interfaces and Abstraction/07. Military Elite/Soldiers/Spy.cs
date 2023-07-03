namespace MilitaryElite.Soldiers;
public class Spy:Soldier
{
    public int CodeNumber { get; private set; }
    public Spy(string id,string fullName,int codeNumber) : base(id,fullName)
    {
        CodeNumber = codeNumber;
    }
    public override string ToString() =>$"{base.ToString()}{Environment.NewLine}Code Number: {CodeNumber}";
}