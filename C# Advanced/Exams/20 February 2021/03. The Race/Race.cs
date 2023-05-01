using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count;}

        public void Add(Racer Racer)
        {
            if(data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            var obj = data.FirstOrDefault(x=>x.Name ==name);
            if(obj != null)
            {
                data.Remove(obj);
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            if(!data.Any())
            {
                return null;
            }
            int max = data.Max(x => x.Age);
            return data.FirstOrDefault(x => x.Age == max);
        }
        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }
        public Racer GetFastestRacer()
        {
            if(!data.Any())
            {
                return null;
            }
            int max = data.Max(x => x.Car.Speed);
            return data.FirstOrDefault(x => x.Car.Speed == max);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach(var obj in data)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
