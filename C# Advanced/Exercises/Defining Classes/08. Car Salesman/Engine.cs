using System.Text;
namespace DefiningClasses;
public class Engine
{
    private string model;
    private int power;
    private int displacement;
    private string efficiency;
    public Engine(string model,int power,int displacement,string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }
    public string Model { get => model; }
    public int Power { get => power; }
    public int Displacement { get => displacement; }
    public string Efficiency { get => efficiency; }
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"  {Model}:");
        sb.AppendLine($"    Power: {Power}");
        string displacementString = Displacement == 0 ? "n/a" : Displacement.ToString();
        sb.AppendLine($"    Displacement: {displacementString}");
        sb.AppendLine($"    Efficiency: {Efficiency}");
        return sb.ToString();
    }
}