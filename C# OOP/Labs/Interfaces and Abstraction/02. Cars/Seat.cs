namespace Cars;
public class Seat:ICar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public Seat(string model,string color)
    {
        Model = model;
        Color = color;
    }
    public string Start()
    {
        return $"{Environment.NewLine}Engine start";
    }
    public string Stop()
    {
        return $"{Environment.NewLine}Breaaak!";
    }
    public override string ToString() => $"{Color} Seat {Model}{Start()}{Stop()}";
}