using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag:IBag
    {
        private int capacity = 100;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Load => items.Sum(x => x.Weight);
        private List<Item> items = new List<Item>();
        public IReadOnlyCollection<Item> Items => items.AsReadOnly();
        public Bag(int capacity)
        {
            Capacity = capacity;
        }
        public void AddItem(Item item)
        {
            if(item.Weight + Load > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }
        public Item GetItem(string name)
        {
            if(items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if(item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            items.Remove(item);
            return item;
        }
    }
}
