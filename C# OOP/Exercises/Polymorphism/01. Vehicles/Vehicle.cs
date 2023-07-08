namespace Vehicles;
public abstract class Vehicle
{
    protected double fuel;
    protected double fuelPerKm;
    protected Vehicle(double fuel,double fuelPerKm)
    {
        this.fuel = fuel;
        this.fuelPerKm = fuelPerKm;
    }
    public string Drive(double km)
    {
        double usedFuel = km * fuelPerKm;
        if(usedFuel <= fuel)
        {
            fuel -= usedFuel;
            return $"{GetType().Name} travelled {km} km";
        }
        return $"{GetType().Name} needs refueling";
    }
    public virtual void Refuel(double liters) => fuel += liters;
    public override string ToString() => $"{GetType().Name}: {fuel:F2}";
}