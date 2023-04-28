using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count{ get => data.Count; }
        public void Add(Pet pet)
        {
            if(Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            var obj = data.FirstOrDefault(x => x.Name == name);
            if(obj != null)
            {
                data.Remove(obj);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name,string owner)
        {
            return data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            if(Count == 0)
            {
                return null;
            }
            int old = data.Max(x=>x.Age);
            return data.FirstOrDefault(x => x.Age == old);
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach(var obj in data)
            {
                sb.AppendLine($"Pet {obj.Name} with owner: {obj.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
