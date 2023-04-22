using System;
namespace DefiningClasses;
public class Car {
    private double fuel;
    private double travelled;
    public double Fuel { get { return fuel; } }
    public double FuelConsumKm { get; }
    public double Travelled { get { return travelled; } }
    public Car(double fuel,double fuelConsumKm) {
        this.fuel = fuel;
        FuelConsumKm = fuelConsumKm;
        travelled = 0;
    }
    public void Drive(int km) {
        double usedFuel = km * FuelConsumKm;
        if(usedFuel <= Fuel) {
            travelled += km;
            fuel -= usedFuel;
        } else Console.WriteLine("Insufficient fuel for the drive");
    }
}