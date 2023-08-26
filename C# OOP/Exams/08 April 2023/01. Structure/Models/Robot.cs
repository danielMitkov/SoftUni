using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot:IRobot
    {
        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }
                model = value;
            }
        }
        private int batteryCapacity;
        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
                batteryCapacity = value;
            }
        }
        private int batteryLevel;
        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }
        private int convertionCapacityIndex;
        public int ConvertionCapacityIndex
        {
            get { return convertionCapacityIndex; }
            private set { convertionCapacityIndex = value; }
        }
        private List<int> interfaceStandards = new List<int>();
        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();
        public Robot(string model,int batteryCapacity,int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            BatteryLevel = BatteryCapacity;
        }
        public void Eating(int minutes)
        {
            BatteryLevel += ConvertionCapacityIndex * minutes;
            if(BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
        }
        public bool ExecuteService(int consumedEnergy)
        {
            if(BatteryLevel < consumedEnergy)
            {
                return false;
            }
            BatteryLevel -= consumedEnergy;
            return true;
        }
        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append("--Supplements installed: ");
            if(interfaceStandards.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                sb.Append(string.Join(" ",interfaceStandards));
            }
            return sb.ToString();
        }
    }
}
