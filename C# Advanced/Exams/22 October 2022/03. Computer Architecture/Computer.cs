using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get { return Multiprocessor.Count; } }
        public Computer(string model,int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        public void Add(CPU cpu)
        {
            if(Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            if(Multiprocessor.Exists(x => x.Brand == brand))
            {
                Multiprocessor.RemoveAll(x => x.Brand == brand);
                return true;
            }
            return false;
        }
        public CPU MostPowerful()
        {
            var bestNum = Multiprocessor.Max(x => x.Frequency);
            return Multiprocessor.Find(x => x.Frequency == bestNum);
        }
        public CPU GetCPU(string brand) => Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        public string Report() => $"CPUs in the Computer {Model}:{Environment.NewLine}{string.Join(Environment.NewLine,Multiprocessor)}";
    }
}
