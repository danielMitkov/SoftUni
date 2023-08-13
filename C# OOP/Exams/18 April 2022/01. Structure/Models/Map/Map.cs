using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(x => x.GetType().Name == "Knight").ToList();
            List<IHero> barbarians = players.Where(x => x.GetType().Name == "Barbarian").ToList();
            while (true)
            {
                foreach (IHero knight in knights.Where(x => x.IsAlive))
                {
                    foreach (IHero barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }
                if (barbarians.Where(x => x.IsAlive).Count() == 0)
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
                if (knights.Where(x => x.IsAlive).Count() == 0)
                {
                    int casualties = barbarians.Where(x => !x.IsAlive).Count();
                    return string.Format(OutputMessages.MapFigthBarbariansWin, casualties);
                }
            }
        }
    }
}
