namespace BorderControl;
public abstract class BaseId:IId
{
    public string Id { get; init; }
    protected BaseId(string id)
    {
        Id = id;
    }
}