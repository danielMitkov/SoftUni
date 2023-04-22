using System.Text;
namespace DefiningClasses;
public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;
    public Car(string model,Engine engine,int weight,string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }
    public string Model { get => model; }
    public Engine Engine { get => engine; }
    public int Weight { get => weight; }
    public string Color { get => color; }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{Model}:");
        sb.Append(Engine);
        string weightString = Weight == 0 ? "n/a" : Weight.ToString();
        sb.AppendLine($"  Weight: {weightString}");
        sb.AppendLine($"  Color: {Color}");
        return sb.ToString();
    }
}