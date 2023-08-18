using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth:IBooth
    {
        private int boothId;
        private int capacity;
        private DelicacyRepository delicacyRepo;
        private CocktailRepository cocktailRepo;
        private double currentBill = 0;
        private double turnover = 0;
        private bool isReserved = false;
        public int BoothId { get => boothId; private set => boothId = value; }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu => delicacyRepo;
        public IRepository<ICocktail> CocktailMenu => cocktailRepo;
        public double CurrentBill { get => currentBill; private set => currentBill = value; }
        public double Turnover { get => turnover; private set => turnover = value; }
        public bool IsReserved { get => isReserved; private set => isReserved = value; }
        public Booth(int boothId,int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
        }
        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }
        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }
        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach(ICocktail cocktail in cocktailRepo.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach(IDelicacy delicacy in delicacyRepo.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}