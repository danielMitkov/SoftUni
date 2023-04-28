using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type,int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count; }
        public void Add(Car car)
        {
            if(Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer,string model)
        {
            var obj = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if(obj != null)
            {
                data.Remove(obj);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if(Count == 0)
            {
                return null;
            }
            int year = data.Max(x => x.Year);
            return data.Find(x => x.Year == year);
        }
        public Car GetCar(string manufacturer,string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach(var obj in data)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
