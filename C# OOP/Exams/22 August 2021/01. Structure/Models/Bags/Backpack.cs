using SpaceStation.Models.Bags.Contracts;
using System.Collections.Generic;
namespace SpaceStation.Models.Bags
{
    public abstract class Backpack:IBag
    {
        private List<string> items = new List<string>();
        public ICollection<string> Items => items;
    }
}
