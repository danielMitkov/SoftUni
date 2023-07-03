namespace BirthdayCelebrations.Identities;
public class Robot : Identity
{
    public string Model { get; init; }
    public Robot(string model, string id) : base(id)
    {
        Model = model;
    }
}