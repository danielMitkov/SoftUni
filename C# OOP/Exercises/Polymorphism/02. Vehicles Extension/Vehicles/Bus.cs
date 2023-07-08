namespace VehiclesExtension.Vehicles;
public class Bus:Vehicle
{
    public Bus(double fuel,double fuelPerKm,double tankCapacity) : base(fuel,fuelPerKm,tankCapacity)
    {
        this.fuelPerKm += 1.4;
    }
    public string DriveEmpty(double km)
    {
        fuelPerKm -= 1.4;
        string result = Drive(km);
        fuelPerKm += 1.4;
        return result;
    }
}