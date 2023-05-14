using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name,int capacity,double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get => Drones.Count; }
        public string AddDrone(Drone drone)
        {
            if(string.IsNullOrEmpty(drone.Name)
                || string.IsNullOrEmpty(drone.Brand)
                || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if(Capacity == Count)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if(drone == null)
            {
                return false;
            }
            Drones.Remove(drone);
            return true;
        }
        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(x => x.Brand == brand);
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);
            if(drone != null)
            {
                drone.Available = false;
                return drone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            foreach(var drone in Drones)
            {
                if(drone.Range >= range)
                {
                    drone.Available = false;
                }
            }
            return Drones.FindAll(x => x.Range >= range);
        }
        public string Report()
        {
            return $"Drones available at {Name}:{Environment.NewLine}{string.Join(Environment.NewLine,Drones.Where(x => x.Available == true))}";
        }
    }
}
