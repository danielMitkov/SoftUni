namespace Vehicles.Vehicles;
public class Truck:Vehicle
{
    public Truck(double fuel,double fuelPerKm) : base(fuel,fuelPerKm)
    {
        this.fuelPerKm += 1.6;
    }
    public override void Refuel(double liters)
    {
        fuel += liters * 0.95;
    }
}