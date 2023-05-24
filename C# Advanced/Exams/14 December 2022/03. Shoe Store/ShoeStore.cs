using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name,int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; private set; }
        public int Count { get => Shoes.Count; }
        public string AddShoe(Shoe shoe)
        {
            if(Shoes.Count < StorageCapacity)
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return "No more space in the storage room.";
        }
        public int RemoveShoes(string material)
        {
            int countToRemove = Shoes.Count(x => x.Material == material);
            Shoes.RemoveAll(x => x.Material == material);
            return countToRemove;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.FindAll(x=>x.Type.ToLower() == type.ToLower());
        }
        public Shoe GetShoeBySize(double size)
        {
            return Shoes.First(x=>x.Size==size);
        }
        public string StockList(double size,string type)
        {
            List<Shoe> shoes = Shoes.FindAll(x=>x.Size == size && x.Type == type);
            if(!shoes.Any())
            {
                return "No matches found!";
            }
            return $"Stock list for size {size} - {type} shoes:{Environment.NewLine}{string.Join(Environment.NewLine,shoes)}";
        }
    }
}
