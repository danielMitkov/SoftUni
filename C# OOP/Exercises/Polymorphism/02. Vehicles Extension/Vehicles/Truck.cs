namespace VehiclesExtension.Vehicles;
public class Truck:Vehicle
{
    public Truck(double fuel,double fuelPerKm,double tankCapacity) : base(fuel,fuelPerKm,tankCapacity)
    {
        this.fuelPerKm += 1.6;
    }
    public override void Refuel(double liters)
    {
        if(liters + fuel > tankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            base.Refuel(liters * 0.95);
        }
    }
}