namespace BorderControl.BaseIds;
public class Robot : BaseId
{
    public string Model { get; init; }
    public Robot(string model, string id) : base(id)
    {
        Model = model;
    }
}