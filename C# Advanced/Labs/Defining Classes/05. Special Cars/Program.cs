namespace CarManufacturer {
    public class StartUp {
        public static void Main() {
            List<Tire[]> tires = new();
            var str = "";
            while((str =Console.ReadLine())!="No more tires") {
                var data = str.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                int year1 = (int)data[0];
                double pressure1 = data[1];
                int year2 = (int)data[2];
                double pressure2 = data[3];
                int year3 = (int)data[4];
                double pressure3 = data[5];
                int year4 = (int)data[6];
                double pressure4 = data[7];
                var tiresArr = new Tire[4] {
                    new Tire(year1,pressure1),
                    new Tire(year2,pressure2),
                    new Tire(year3,pressure3),
                    new Tire(year4,pressure4)
                };
                tires.Add(tiresArr);
            }
            List<Engine> engines = new();
            while((str=Console.ReadLine())!="Engines done") {
                var data = str.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                int horsePower = (int)data[0];
                double cubicCapacity = data[1];
                engines.Add(new Engine(horsePower,cubicCapacity)); 
            }
            List<Car> cars = new();
            while((str=Console.ReadLine())!="Show special") {
                var data = str.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string make = data[0].ToString();
                string model = data[1].ToString();
                int year = int.Parse(data[2]);
                double fuelQuantity = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tiresIndex = int.Parse(data[6]);
                cars.Add(new Car(make,model,year,fuelQuantity,fuelConsumption,engines[engineIndex],tires[tiresIndex]));
            }
            var winners = cars.Where(x => x.Year>=2017&&x.Engine.HorsePower>330&&x.Tires.Sum(y => y.Pressure)>=9&&x.Tires.Sum(y => y.Pressure)<=10).ToList();
            if(winners.Any()) {
                foreach(var car in winners) {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}