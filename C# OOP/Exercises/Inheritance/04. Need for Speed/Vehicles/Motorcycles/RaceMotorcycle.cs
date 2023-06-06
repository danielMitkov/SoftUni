using NeedForSpeed.Vehicles;

namespace NeedForSpeed.Vehicles.Motorcycles;
public class RaceMotorcycle : Motorcycle
{
    public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
    {
        DefaultFuelConsumption = 8;
    }
}