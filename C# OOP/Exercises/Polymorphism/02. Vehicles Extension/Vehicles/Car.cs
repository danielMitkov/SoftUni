namespace VehiclesExtension.Vehicles;
public class Car:Vehicle
{
    public Car(double fuel,double fuelPerKm,double tankCapacity) : base(fuel,fuelPerKm,tankCapacity)
    {
        this.fuelPerKm += 0.9;
    }
}