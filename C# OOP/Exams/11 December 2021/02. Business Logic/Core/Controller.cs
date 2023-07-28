using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Gym.Core
{
    public class Controller:IController
    {
        private EquipmentRepository equipment = new EquipmentRepository();
        private List<IGym> gyms = new List<IGym>();
        public string AddAthlete(string gymName,string athleteType,string athleteName,string motivation,int numberOfMedals)
        {
            if(athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            IGym gym = gyms.Find(x => x.Name == gymName);
            if(athleteType == nameof(Boxer) && gym.GetType().Name != nameof(BoxingGym))
            {
                return "The gym is not appropriate.";
            }
            if(athleteType == nameof(Weightlifter) && gym.GetType().Name != nameof(WeightliftingGym))
            {
                return "The gym is not appropriate.";
            }
            IAthlete athlete = null;
            if(athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName,motivation,numberOfMedals);
            }
            if(athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName,motivation,numberOfMedals);
            }
            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }
        public string AddEquipment(string equipmentType)
        {
            if(equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            IEquipment equipment = null;
            if(equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            if(equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            this.equipment.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }
        public string AddGym(string gymType,string gymName)
        {
            if(gymType != nameof(BoxingGym) && gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            IGym gym = null;
            if(gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            if(gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.Find(x => x.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }
        public string InsertEquipment(string gymName,string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if(equipment == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            gyms.Find(x => x.Name == gymName).AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IGym gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }
        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.Find(x => x.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
