using Vehicles;
using Vehicles.Vehicles;
string[] carData = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
Vehicle car = new Car(double.Parse(carData[1]),double.Parse(carData[2]));
string[] truckData = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
Vehicle truck = new Truck(double.Parse(truckData[1]),double.Parse(truckData[2]));
for(int n = int.Parse(Console.ReadLine());n > 0;--n)
{
    string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
    switch(data[0] + data[1])
    {
        case "DriveCar":
            Console.WriteLine(car.Drive(double.Parse(data[2])));
            break;
        case "DriveTruck":
            Console.WriteLine(truck.Drive(double.Parse(data[2])));
            break;
        case "RefuelCar":
            car.Refuel(double.Parse(data[2]));
            break;
        case "RefuelTruck":
            truck.Refuel(double.Parse(data[2]));
            break;
    }
}
Console.WriteLine(car);
Console.WriteLine(truck);