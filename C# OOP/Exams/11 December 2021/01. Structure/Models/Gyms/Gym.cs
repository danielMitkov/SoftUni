using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Gym.Models.Gyms
{
    public abstract class Gym:IGym
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public double EquipmentWeight => equipment.Sum(x => x.Weight);
        private List<IEquipment> equipment = new List<IEquipment>();
        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();
        private List<IAthlete> athletes = new List<IAthlete>();
        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();
        public Gym(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public void AddAthlete(IAthlete athlete)
        {
            if(athletes.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            athletes.Add(athlete);
        }
        public void AddEquipment(IEquipment equipment) => this.equipment.Add(equipment);
        public void Exercise()
        {
            foreach(IAthlete athlete in athletes)
            {
                athlete.Exercise();
            }
        }
        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.Append($"Athletes: ");
            if(athletes.Any())
            {
                sb.AppendLine(string.Join(", ",athletes.Select(x => x.FullName)));
            }
            else
            {
                sb.AppendLine("No athletes");
            }
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.Append($"Equipment total weight: {EquipmentWeight} grams");
            return sb.ToString();
        }
        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);
    }
}
