using System.Collections.Generic;
namespace DefiningClasses;
public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;
    public Car(string model,Engine engine,Cargo cargo,Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
    public string Model { get => model; }
    public Engine Engine { get => engine; }
    public Cargo Cargo { get => cargo; }
    public Tire[] Tires { get => tires; }
    public override string ToString()
    {
        return model;
    }
}