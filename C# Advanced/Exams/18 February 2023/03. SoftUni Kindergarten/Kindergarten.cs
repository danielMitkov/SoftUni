using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount { get => Registry.Count; }

        public bool AddChild(Child child)
        {
            if(Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            string[] names = childFullName.Split(" ");
            var obj = Registry.FirstOrDefault(x=>x.FirstName == names[0] && x.LastName == names[1]);
            if(obj != null)
            {
                Registry.Remove(obj);
                return true;
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string[] names = childFullName.Split(" ");
            var obj = Registry.FirstOrDefault(x => x.FirstName == names[0] && x.LastName == names[1]);
            return obj;
        }
        public string RegistryReport()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Registered children in {Name}:");
            foreach(var obj in Registry.OrderByDescending(x=>x.Age).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName))
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
