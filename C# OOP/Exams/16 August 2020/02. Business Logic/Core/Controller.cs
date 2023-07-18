using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OnlineShop.Core
{
    public class Controller:IController
    {
        List<IComputer> computers = new List<IComputer>();
        List<IComponent> components = new List<IComponent>();
        List<IPeripheral> peripherals = new List<IPeripheral>();
        public string AddComponent(int computerId,int id,string componentType,string manufacturer,string model,decimal price,double overallPerformance,int generation)
        {
            if(components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }
            IComponent component = null;
            switch(componentType)
            {
                case nameof(CentralProcessingUnit):
                    component = new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case nameof(Motherboard):
                    component = new Motherboard(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case nameof(PowerSupply):
                    component = new PowerSupply(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case nameof(RandomAccessMemory):
                    component = new RandomAccessMemory(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case nameof(SolidStateDrive):
                    component = new SolidStateDrive(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                case nameof(VideoCard):
                    component = new VideoCard(id,manufacturer,model,price,overallPerformance,generation);
                    break;
                default:
                    throw new ArgumentException("Component type is invalid.");
            }
            IComputer computer = GetComputerCheck(computerId);
            computer.AddComponent(component);
            components.Add(component);
            return $"Component {component.GetType().Name} with id {component.Id} added successfully in computer with id {computer.Id}.";
        }
        public string AddComputer(string computerType,int id,string manufacturer,string model,decimal price)
        {
            if(computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            IComputer computer = null;
            switch(computerType)
            {
                case nameof(DesktopComputer):
                    computer = new DesktopComputer(id,manufacturer,model,price);
                    break;
                case nameof(Laptop):
                    computer = new Laptop(id,manufacturer,model,price);
                    break;
                default:
                    throw new ArgumentException("Computer type is invalid.");
            }
            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }
        public string AddPeripheral(int computerId,int id,string peripheralType,string manufacturer,string model,decimal price,double overallPerformance,string connectionType)
        {
            if(peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            IPeripheral peripheral = null;
            switch(peripheralType)
            {
                case nameof(Headset):
                    peripheral = new Headset(id,manufacturer,model,price,overallPerformance,connectionType);
                    break;
                case nameof(Keyboard):
                    peripheral = new Keyboard(id,manufacturer,model,price,overallPerformance,connectionType);
                    break;
                case nameof(Monitor):
                    peripheral = new Monitor(id,manufacturer,model,price,overallPerformance,connectionType);
                    break;
                case nameof(Mouse):
                    peripheral = new Mouse(id,manufacturer,model,price,overallPerformance,connectionType);
                    break;
                default:
                    throw new ArgumentException("Peripheral type is invalid.");
            }
            IComputer computer = GetComputerCheck(computerId);
            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computer.Id}.";
        }
        public string BuyBest(decimal budget)
        {
            if(computers.Count == 0 || !computers.Any(x => x.Price <= budget))
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            IComputer computer = computers.Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance).First();
            computers.Remove(computer);
            return computer.ToString();
        }
        public string BuyComputer(int id)
        {
            IComputer computer = GetComputerCheck(id);
            computers.Remove(computer);
            return computer.ToString();
        }
        public string GetComputerData(int id)
        {
            IComputer computer = GetComputerCheck(id);
            return computer.ToString();
        }
        public string RemoveComponent(string componentType,int computerId)
        {
            IComputer computer = GetComputerCheck(computerId);
            IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);
            return $"Successfully removed {componentType} with id {component.Id}.";
        }
        public string RemovePeripheral(string peripheralType,int computerId)
        {
            IComputer computer = GetComputerCheck(computerId);
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }
        private IComputer GetComputerCheck(int id)
        {
            IComputer computer = computers.FirstOrDefault(x => x.Id == id);
            if(computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            return computer;
        }
    }
}
