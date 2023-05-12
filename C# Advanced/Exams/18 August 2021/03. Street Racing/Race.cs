using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name,string type,int laps,int capacity,int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants { get; set; }
        public int Count { get => Participants.Count; }
        public void Add(Car car)
        {
            if(Participants.Exists(x=>x.LicensePlate == car.LicensePlate))
            {
                return;
            }
            if(Capacity == Count)
            {
                return;
            }
            if(car.HorsePower <= MaxHorsePower)//UNCLEAR CONDITION !!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            Car car = Participants.FirstOrDefault(x=>x.LicensePlate == licensePlate);
            if(car != null)
            {
                Participants.Remove(car);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }
        public Car GetMostPowerfulCar()
        {
            if(Count == 0)
            {
                return null;
            }
            int max = Participants.Max(x=>x.HorsePower);
            return Participants.Find(x=>x.HorsePower == max);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach(Car car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
