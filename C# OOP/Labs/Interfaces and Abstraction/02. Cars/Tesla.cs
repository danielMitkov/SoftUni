namespace Cars;
public class Tesla:ICar, IElectricCar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }
    public Tesla(string model,string color,int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }
    public string Start()
    {
        return $"{Environment.NewLine}Engine start";
    }
    public string Stop()
    {
        return $"{Environment.NewLine}Breaaak!";
    }
    public override string ToString() => $"{Color} Tesla {Model} with {Battery} Batteries{Start()}{Stop()}";
}