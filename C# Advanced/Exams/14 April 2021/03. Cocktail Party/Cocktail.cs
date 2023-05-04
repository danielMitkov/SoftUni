using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name,int capacity,int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {//LOOK FOR ERROR HERE
            if(Ingredients.Any(x=>x.Name == ingredient.Name))
            {
                return;
            }
            if(Capacity == Ingredients.Count)
            {
                return;
            }
            Ingredients.Add(ingredient);
            CurrentAlcoholLevel += ingredient.Alcohol;
        }
        public bool Remove(string name)
        {
            var obj = Ingredients.FirstOrDefault(x=>x.Name == name);
            if(obj != null)
            {
                Ingredients.Remove(obj);
                CurrentAlcoholLevel -= obj.Alcohol;
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            int max = Ingredients.Max(x=>x.Alcohol);
            return Ingredients.FirstOrDefault(x=>x.Alcohol==max);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach(var obj in Ingredients)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
