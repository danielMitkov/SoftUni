using VehiclesExtension;
using VehiclesExtension.Vehicles;
List<Vehicle> vehicles = new();
for(int n = 3;n > 0;--n)
{
    string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
    string type = data[0];
    double fuel = double.Parse(data[1]);
    double fuelPerKm = double.Parse(data[2]);
    double tankCapacity = double.Parse(data[3]);
    switch(type)
    {
        case "Car":
            vehicles.Add(new Car(fuel,fuelPerKm,tankCapacity));
            break;
        case "Truck":
            vehicles.Add(new Truck(fuel,fuelPerKm,tankCapacity));
            break;
        case "Bus":
            vehicles.Add(new Bus(fuel,fuelPerKm,tankCapacity));
            break;
    }
}
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
    switch(data[0] + data[1])
    {
        case "DriveCar":
            Console.WriteLine(vehicles[0].Drive(double.Parse(data[2])));
            break;
        case "DriveTruck":
            Console.WriteLine(vehicles[1].Drive(double.Parse(data[2])));
            break;
        case "DriveBus":
            Console.WriteLine(vehicles[2].Drive(double.Parse(data[2])));
            break;
        case "DriveEmptyBus":
            Console.WriteLine(((Bus)vehicles[2]).DriveEmpty(double.Parse(data[2])));
            break;
        case "RefuelCar":
            vehicles[0].Refuel(double.Parse(data[2]));
            break;
        case "RefuelTruck":
            vehicles[1].Refuel(double.Parse(data[2]));
            break;
        case "RefuelBus":
            vehicles[2].Refuel(double.Parse(data[2]));
            break;
    }
}
foreach(Vehicle vehicle in vehicles)
{
    Console.WriteLine(vehicle);
}