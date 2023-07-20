using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table:ITable
    {
        private List<IBakedFood> FoodOrders = new List<IBakedFood>();
        private List<IDrink> DrinkOrders = new List<IDrink>();
        private int tableNumber;
        public int TableNumber
        {
            get { return tableNumber; }
            private set { tableNumber = value; }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }
        private int numberOfPeople;
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }
        private decimal pricePerPerson;
        public decimal PricePerPerson
        {
            get { return pricePerPerson; }
            private set { pricePerPerson = value; }
        }
        private bool isReserved;
        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }
        public decimal Price => NumberOfPeople * PricePerPerson;
        public Table(int tableNumber,int capacity,decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }
        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            NumberOfPeople = 0;
        }
        public decimal GetBill() => FoodOrders.Sum(x => x.Price) + DrinkOrders.Sum(x => x.Price);
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson}");
            return sb.ToString();
        }
        public void OrderDrink(IDrink drink) => DrinkOrders.Add(drink);
        public void OrderFood(IBakedFood food) => FoodOrders.Add(food);
        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
