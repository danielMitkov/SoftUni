using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Bakery.Core
{
    public class Controller:IController
    {
        private List<IBakedFood> bakedFoods = new List<IBakedFood>();
        private List<IDrink> drinks = new List<IDrink>();
        private List<ITable> tables = new List<ITable>();
        private decimal income = 0;
        public string AddDrink(string type,string name,int portion,string brand)
        {
            IDrink drink = null;
            if(type == nameof(Tea))
            {
                drink = new Tea(name,portion,brand);
            }
            else
            {
                drink = new Water(name,portion,brand);
            }
            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }
        public string AddFood(string type,string name,decimal price)
        {
            IBakedFood food = null;
            if(type == nameof(Bread))
            {
                food = new Bread(name,price);
            }
            else
            {
                food = new Cake(name,price);
            }
            bakedFoods.Add(food);
            return $"Added {name} ({type}) to the menu";
        }
        public string AddTable(string type,int tableNumber,int capacity)
        {
            ITable table = null;
            if(type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber,capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber,capacity);
            }
            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }
        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach(ITable table in tables.Where(x => !x.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }
        public string GetTotalIncome() => $"Total income: {income:F2}lv";
        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.Find(x => x.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            table.Clear();
            income += bill;
            return $"Table: {tableNumber}{Environment.NewLine}Bill: {bill:F2}";
        }
        public string OrderDrink(int tableNumber,string drinkName,string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if(table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if(drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }
        public string OrderFood(int tableNumber,string foodName)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if(table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if(food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }
        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(x => !x.IsReserved && x.Capacity >= numberOfPeople);
            if(table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
