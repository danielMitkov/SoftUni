namespace MilitaryElite;
public class Mission
{
    private string state;
    public string CodeName { get; private set; }
    public string State
    {
        get => state;
        private set
        {
            if(value != "inProgress" && value != "Finished")
            {
                throw new ArgumentException("invalid state");
            }
            state = value;
        }
    }
    public Mission(string codeName,string state)
    {
        CodeName = codeName;
        State = state;
    }
    public override string ToString() => $"  Code Name: {CodeName} State: {State}";
}