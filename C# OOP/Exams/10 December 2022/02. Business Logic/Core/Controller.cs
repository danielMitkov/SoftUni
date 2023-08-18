using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller:IController
    {
        private BoothRepository booths = new BoothRepository();
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId,capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded,boothId,capacity);
        }
        public string AddCocktail(int boothId,string type,string name,string size)
        {
            if(type != "Hibernation" && type != "MulledWine")
            {
                return string.Format(OutputMessages.InvalidCocktailType,type);
            }
            if(size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize,size);
            }
            if(booths.Models.Any(x => x.CocktailMenu.Models.Any(x => x.Name == name && x.Size == size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded,size,name);
            }
            ICocktail cocktail;
            if(type == "MulledWine")
            {
                cocktail = new MulledWine(name,size);
            }
            else
            {
                cocktail = new Hibernation(name,size);
            }
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded,size,name,type);
        }
        public string AddDelicacy(int boothId,string type,string name)
        {
            if(type != "Gingerbread" && type != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType,type);
            }
            if(booths.Models.Any(x => x.DelicacyMenu.Models.Any(x => x.Name == name)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded,name);
            }
            IDelicacy delicacy;
            if(type == "Gingerbread")
            {
                delicacy = new Gingerbread(name);
            }
            else
            {
                delicacy = new Stolen(name);
            }
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded,type,name);
        }
        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.SingleOrDefault(x => x.BoothId == boothId);
            return booth.ToString();
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.SingleOrDefault(x => x.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.GetBill,$"{booth.CurrentBill:F2}"));
            booth.Charge();
            booth.ChangeStatus();
            sb.Append(string.Format(OutputMessages.BoothIsAvailable,boothId));
            return sb.ToString().TrimEnd();
        }
        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity)
                .ThenByDescending(x => x.BoothId)
                .FirstOrDefault();
            if(booth != null)
            {
                booth.ChangeStatus();
                return string.Format(OutputMessages.BoothReservedSuccessfully,booth.BoothId,countOfPeople);
            }
            return string.Format(OutputMessages.NoAvailableBooth,countOfPeople);
        }
        public string TryOrder(int boothId,string order)
        {
            string[] data = order.Split("/");
            string type = data[0];
            string name = data[1];
            int count = int.Parse(data[2]);
            string size = string.Empty;
            Type typeCocktail = Type.GetType($"ChristmasPastryShop.Models.Cocktails.{type}");
            Type typeDelicacy = Type.GetType($"ChristmasPastryShop.Models.Delicacies.{type}");
            if(typeCocktail == null && typeDelicacy == null)
            {
                return string.Format(OutputMessages.NotRecognizedType,type);
            }
            if(typeCocktail != null)
            {
                size = data[3];
            }
            IBooth booth = booths.Models.SingleOrDefault(x => x.BoothId == boothId);
            if(!booth.CocktailMenu.Models.Any(x => x.Name == name) &&
                !booth.DelicacyMenu.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.NotRecognizedItemName,type,name);
            }
            if(typeCocktail != null)
            {
                ICocktail cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(x => type == x.GetType().Name && name == x.Name && size == x.Size);
                if(cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded,size,name);
                }
                booth.UpdateCurrentBill(cocktail.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered,boothId,count,name);
            }
            else
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(x => type == x.GetType().Name && name == x.Name);
                if(delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded,size,name);
                }
                booth.UpdateCurrentBill(delicacy.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered,boothId,count,name);
            }
        }
    }
}