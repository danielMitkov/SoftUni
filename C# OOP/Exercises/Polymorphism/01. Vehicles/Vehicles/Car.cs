namespace Vehicles.Vehicles;
public class Car:Vehicle
{
    public Car(double fuel,double fuelPerKm) : base(fuel,fuelPerKm)
    {
        this.fuelPerKm += 0.9;
    }
}