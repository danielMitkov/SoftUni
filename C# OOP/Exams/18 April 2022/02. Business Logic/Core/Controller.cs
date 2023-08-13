using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
namespace Heroes.Core
{
    public class Controller:IController
    {
        IRepository<IHero> heroes = new HeroRepository();
        IRepository<IWeapon> weapons = new WeaponRepository();
        public string AddWeaponToHero(string weaponName,string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if(hero == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages
                    .HeroDoesNotExist,heroName));
            }
            IWeapon weapon = weapons.FindByName(weaponName);
            if(weapon == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages
                    .WeaponDoesNotExist,weaponName));
            }
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages
                    .HeroAlreadyHasWeapon,hero.Name));
            }
            weapons.Remove(weapon);
            hero.AddWeapon(weapon);
            return string.Format(OutputMessages
                .WeaponAddedToHero,hero.Name,weapon.GetType().Name.ToLower());
        }
        public string CreateHero(string type,string name,int health,int armour)
        {
            if(heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages
                    .HeroAlreadyExist,name));
            }
            if(type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException(OutputMessages.HeroTypeIsInvalid);
            }
            if(type == "Barbarian")
            {
                IHero hero = new Barbarian(name,health,armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian,name);
            }
            else
            {
                IHero hero = new Knight(name,health,armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedKnight,name);
            }
        }
        public string CreateWeapon(string type,string name,int durability)
        {
            if(weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages
                    .WeaponAlreadyExists,name));
            }
            if(type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid);
            }
            IWeapon weapon = null;
            if(type == "Mace")
            {
                weapon = new Mace(name,durability);
            }
            else
            {
                weapon = new Claymore(name,durability);
            }
            weapons.Add(weapon);
            return string.Format(OutputMessages.WeaponAddedSuccessfully,type.ToLower(),name);
        }
        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IHero hero in heroes.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.Append("--Weapon: ");
                if(hero.Weapon == null)
                {
                    sb.AppendLine("Unarmed");
                }
                else
                {
                    sb.AppendLine(hero.Weapon.Name);
                }
            }
            return sb.ToString().TrimEnd();
        }
        public string StartBattle()
        {
            IMap map = new Map();
            List<IHero> fits = heroes.Models.Where(x => x.IsAlive && x.Weapon != null).ToList();
            return map.Fight(fits);
        }
    }
}
