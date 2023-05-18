using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material,int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }
        public List<Fish> Fish { get; set; }
        public string Material { get;private set; }
        public int Capacity { get;private set; }
        public int Count { get => Fish.Count; }
        public string AddFish(Fish fish)
        {
            if(string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if(Count == Capacity)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            Fish fish = Fish.FirstOrDefault(x=>x.Weight == weight);
            if(fish == null)
            {
                return false;
            }
            Fish.Remove(fish);
            return true;
        }
        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(x=>x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            double max = Fish.Max(x=>x.Length);
            return Fish.Find(x=>x.Length == max);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach(Fish fish in Fish.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
