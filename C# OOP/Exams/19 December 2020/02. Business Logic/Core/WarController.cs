using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters = new List<Character>();
        private Stack<Item> items = new Stack<Item>();
        public string JoinParty(string[] args)
        {
            string type = args[0];
            string name = args[1];
            Character character = null;
            switch(type)
            {
                case nameof(Warrior):
                    character = new Warrior(name);
                    break;
                case nameof(Priest):
                    character = new Priest(name);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }
            characters.Add(character);
            return $"{name} joined the party!";
        }
        public string AddItemToPool(string[] args)
        {
            string type = args[0];
            Item item = null;
            switch(type)
            {
                case nameof(FirePotion):
                    item = new FirePotion();
                    break;
                case nameof(HealthPotion):
                    item = new HealthPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{type}\"!");
            }
            items.Push(item);
            return $"{type} added to pool.";
        }
        public string PickUpItem(string[] args)
        {
            string charactedName = args[0];
            Character character = characters.FirstOrDefault(x => x.Name == charactedName);
            if(character == null)
            {
                throw new ArgumentException($"Character {charactedName} not found!");
            }
            if(items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            Item item = items.Pop();
            character.Bag.AddItem(item);
            return $"{charactedName} picked up {item.GetType().Name}!";
        }
        public string UseItem(string[] args)
        {
            string charactedName = args[0];
            Character character = characters.FirstOrDefault(x => x.Name == charactedName);
            if(character == null)
            {
                throw new ArgumentException($"Character {charactedName} not found!");
            }
            string itemName = args[1];
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }
        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Character c in characters.OrderByDescending(x => x.Health))
            {
                string status = c.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: {status}");
            }
            return sb.ToString().TrimEnd();
        }
        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);
            if(attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if(receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if(attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            ((Warrior)attacker).Attack(receiver);
            string output = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";
            if(receiver.IsAlive == false)
            {
                output += $"{Environment.NewLine}{receiverName} is dead!";
            }
            return output;
        }
        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];
            Character healer = characters.FirstOrDefault(x => x.Name == healerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);
            if(healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if(receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if(healer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            ((Priest)healer).Heal(receiver);
            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
