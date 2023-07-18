using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer:Product, IComputer
    {
        private List<IComponent> components = new List<IComponent>();
        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();
        List<IPeripheral> peripherals = new List<IPeripheral>();
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();
        public override double OverallPerformance
        {
            get
            {
                if(components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + components.Average(x=>x.OverallPerformance);
            }
        }
        public override decimal Price 
            => base.Price + components.Sum(x=>x.Price) + peripherals.Sum(x=>x.Price);
        protected Computer(int id,string manufacturer,string model,decimal price,double overallPerformance) : base(id,manufacturer,model,price,overallPerformance)
        {
        }
        public void AddComponent(IComponent component)
        {
            string type = component.GetType().Name;
            if(components.Any(x=>x.GetType().Name == type))
            {
                throw new ArgumentException($"Component {type} already exists in {GetType().Name} with Id {Id}.");
            }
            components.Add(component);
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            string type = peripheral.GetType().Name;
            if(peripherals.Any(x=>x.GetType().Name == type))
            {
                throw new ArgumentException($"Peripheral {type} already exists in {GetType().Name} with Id {Id}.");
            }
            peripherals.Add(peripheral);
        }
        public IComponent RemoveComponent(string type)
        {
            if(components.Count == 0 || !components.Any(x=>x.GetType().Name == type))
            {
                throw new ArgumentException($"Component {type} does not exist in {GetType().Name} with Id {Id}.");
            }
            IComponent component = components.First(x=>x.GetType().Name==type);
            components.Remove(component);
            return component;
        }
        public IPeripheral RemovePeripheral(string type)
        {
            if(peripherals.Count == 0 || !peripherals.Any(x=>x.GetType().Name == type))
            {
                throw new ArgumentException($"Peripheral {type} does not exist in {GetType().Name} with Id {Id}.");
            }
            IPeripheral peripheral = peripherals.First(x=>x.GetType().Name == type);
            peripherals.Remove(peripheral);
            return peripheral;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({components.Count}):");
            if(components.Any())
            {
                sb.AppendLine(string.Join(Environment.NewLine,components.Select(x => $"  {x}")));
            }
            double average = peripherals.Any() ? peripherals.Average(x => x.OverallPerformance) : 0;
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({average:F2}):");
            if(peripherals.Any())
            {
                sb.AppendLine(string.Join(Environment.NewLine,peripherals.Select(x => $"  {x}")));
            }
            return sb.ToString().TrimEnd();
        }
    }
}
