using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SoftUniParking;
public class Parking
{
    private Dictionary<string,Car> cars;
    private int capacity;
    public Parking(int capacity)
    {
        cars = new();
        this.capacity = capacity;
    }
    public Dictionary<string,Car> Cars { get => cars; }
    public int Capacity { get => capacity; }
    public int Count
    {
        get
        {
            return cars.Count;
        }
    }
    public string AddCar(Car car)
    {
        if(cars.ContainsKey(car.RegistrationNumber))
        {
            return "Car with that registration number, already exists!";
        }
        if(cars.Count == capacity)
        {
            return "Parking is full!";
        }
        cars.Add(car.RegistrationNumber,car);
        return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
    }
    public string RemoveCar(string registrationNumber)
    {
        if(!cars.ContainsKey(registrationNumber))
        {
            return "Car with that registration number, doesn't exist!";
        }
        cars.Remove(registrationNumber);
        return $"Successfully removed {registrationNumber}";
    }
    public Car GetCar(string RegistrationNumber)
    {
        if(cars.ContainsKey(RegistrationNumber))
        {
            return cars[RegistrationNumber];
        }
        return null;
    }
    public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
    {
        foreach(var id in RegistrationNumbers)
        {
            if(cars.ContainsKey(id))
            {
                cars.Remove(id);
            }
        }
    }
}