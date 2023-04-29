using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count; }
        public void Add(Employee employee)
        {
            if(Count < Capacity)
            {
                data.Add(employee);
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
        public Employee GetOldestEmployee()
        {
            if(Count == 0)
            {
                return null;
            }
            int age = data.Max(x=>x.Age);
            return data.FirstOrDefault(x=>x.Age==age);
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x=>x.Name==name);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach(var obj in data)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
