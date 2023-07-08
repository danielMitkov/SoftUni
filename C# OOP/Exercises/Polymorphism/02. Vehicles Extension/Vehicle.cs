namespace VehiclesExtension;
public abstract class Vehicle
{
    protected double fuel;
    protected double fuelPerKm;
    protected double tankCapacity;
    protected Vehicle(double fuel,double fuelPerKm,double tankCapacity)
    {
        this.tankCapacity = tankCapacity;
        if(fuel > tankCapacity)
        {
            this.fuel = 0;
        }
        else
        {
            this.fuel = fuel;
        }
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
    public virtual void Refuel(double liters)
    {
        if(liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if(liters + fuel > tankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            fuel += liters;
        }
    }
    public override string ToString() => $"{GetType().Name}: {fuel:F2}";
}