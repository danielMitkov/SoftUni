using System;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
namespace WarCroft.Entities.Characters
{
    public class Warrior:Character, IAttacker
    {
        public Warrior(string name) : base(name,100,50,40,new Satchel())
        {
        }
        public void Attack(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();
            if(character.Equals(this))
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            character.TakeDamage(AbilityPoints);
        }
    }
}
