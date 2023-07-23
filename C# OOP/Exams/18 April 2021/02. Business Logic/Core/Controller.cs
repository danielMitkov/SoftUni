using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Easter.Core
{
    public class Controller:IController
    {
        private BunnyRepository bunnies = new BunnyRepository();
        private EggRepository eggs = new EggRepository();
        public string AddBunny(string bunnyType,string bunnyName)
        {
            IBunny bunny = null;
            switch(bunnyType)
            {
                case nameof(HappyBunny):
                    bunny = new HappyBunny(bunnyName);
                    break;
                case nameof(SleepyBunny):
                    bunny = new SleepyBunny(bunnyName);
                    break;
                default:
                    throw new InvalidOperationException("Invalid bunny type.");
            }
            bunnies.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }
        public string AddDyeToBunny(string bunnyName,int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if(bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }
            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }
        public string AddEgg(string eggName,int energyRequired)
        {
            IEgg egg = new Egg(eggName,energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }
        public string ColorEgg(string eggName)
        {
            List<IBunny> selected = bunnies.Models.Where(x => x.Energy >= 50).ToList();
            if(!selected.Any())
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }
            IEgg egg = eggs.FindByName(eggName);
            Workshop workshop = new Workshop();
            foreach(IBunny bunny in selected.OrderByDescending(x => x.Energy))
            {
                workshop.Color(egg,bunny);
                if(bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
            }
            if(egg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int eggsDone = eggs.Models.Where(x => x.IsDone()).Count();
            sb.AppendLine($"{eggsDone} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach(IBunny bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                int dyesAvailable = bunny.Dyes.Where(x => !x.IsFinished()).Count();
                sb.AppendLine($"Dyes: {dyesAvailable} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
