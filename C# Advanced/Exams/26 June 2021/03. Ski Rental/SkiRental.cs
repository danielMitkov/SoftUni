using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name,int capacity)
        {
            Capacity = capacity;
            Name = name;
            data = new List<Ski>();
        }

        public int Capacity { get; set; }
        public string Name { get; set; }
        public int Count { get => data.Count; }

        public void Add(Ski ski)
        {
            if(Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer,string model)
        {
            Ski ski = data.FirstOrDefault(x=>x.Manufacturer == manufacturer && x.Model == model);
            if(ski != null)
            {
                data.Remove(ski);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if(data.Count == 0)
            {
                return null;
            }
            int newest = data.Max(x=>x.Year);
            return data.Find(x=>x.Year == newest);
        }
        public Ski GetSki(string manufacturer,string model)
        {
            return data.FirstOrDefault(x=>x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach(var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
