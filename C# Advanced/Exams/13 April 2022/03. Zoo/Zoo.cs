using System.Collections.Generic;
using System.Linq;
namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }
        public string AddAnimal(Animal animal)
        {
            if(animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            if(animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if(Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(x => x.Species == species);
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(x => x.Diet == diet);
        }
        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength,double maximumLength)
        {
            List<Animal> matches = Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength);
            return $"There are {matches.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}