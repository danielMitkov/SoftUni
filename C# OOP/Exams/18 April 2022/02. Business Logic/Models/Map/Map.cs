using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Utilities.Messages;
namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(x => x.GetType() == typeof(Knight)).ToList();
            List<IHero> barbarians = players.Where(x => x.GetType() == typeof(Barbarian)).ToList();
            while (true)
            {
                foreach (IHero knight in knights.Where(x => x.IsAlive))
                {
                    foreach (IHero barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }
                if (!barbarians.Any(x => x.IsAlive))
                {
                    int casualties = knights.Where(x => !x.IsAlive).Count();
                    return string.Format(OutputMessages.MapFightKnightsWin, casualties);
                }
                foreach (IHero barbarian in barbarians.Where(x => x.IsAlive))
                {
                    foreach (IHero knight in knights.Where(x => x.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
                if (!knights.Any(x => x.IsAlive))
                {
                    int casualties = barbarians.Where(x => !x.IsAlive).Count();
                    return string.Format(OutputMessages.MapFigthBarbariansWin, casualties);
                }
            }
        }
    }
}
