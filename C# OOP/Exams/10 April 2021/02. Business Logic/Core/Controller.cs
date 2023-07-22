using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller:IController
    {
        DecorationRepository decorations = new DecorationRepository();
        List<IAquarium> aquariums = new List<IAquarium>();
        public string AddAquarium(string type,string name)
        {
            IAquarium aquarium = null;
            switch(type)
            {
                case nameof(FreshwaterAquarium):
                    aquarium = new FreshwaterAquarium(name);
                    break;
                case nameof(SaltwaterAquarium):
                    aquarium = new SaltwaterAquarium(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aquarium);
            return $"Successfully added {type}.";
        }
        public string AddDecoration(string type)
        {
            IDecoration decoration = null;
            switch(type)
            {
                case nameof(Ornament):
                    decoration = new Ornament();
                    break;
                case nameof(Plant):
                    decoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException("Invalid decoration type.");
            }
            decorations.Add(decoration);
            return $"Successfully added {type}.";
        }
        public string AddFish(string aquariumName,string fishType,string fishName,string fishSpecies,decimal price)
        {
            IFish fish = null;
            switch(fishType)
            {
                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName,fishSpecies,price);
                    break;
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName,fishSpecies,price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid fish type.");
            }
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            if(fishType == nameof(FreshwaterFish) && aquarium.GetType().Name != nameof(FreshwaterAquarium)
                || fishType == nameof(SaltwaterFish) && aquarium.GetType().Name != nameof(SaltwaterAquarium))
            {
                return "Water not suitable.";
            }
            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }
        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            decimal fishPrices = aquarium.Fish.Sum(x => x.Price);
            decimal decorationsPrices = aquarium.Decorations.Sum(x => x.Price);
            decimal totalPrice = fishPrices + decorationsPrices;
            return $"The value of Aquarium {aquariumName} is {totalPrice:F2}.";
        }
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }
        public string InsertDecoration(string aquariumName,string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if(decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            IAquarium aquarium = aquariums.First(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }
        public string Report() => string.Join(Environment.NewLine,aquariums.Select(x => x.GetInfo()));
    }
}
