using System.Collections.Generic;
using System.Linq;
namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName,string emailAddress,decimal moneyToInvest,string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get => Portfolio.Count; }
        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName,decimal sellPrice)
        {
            Stock stock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if(stock == null)
            {
                return $"{companyName} does not exist.";
            }
            if(sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            if(!Portfolio.Any())
            {
                return null;
            }
            decimal biggestNum = Portfolio.Max(x => x.MarketCapitalization);
            return Portfolio.Find(x => x.MarketCapitalization == biggestNum);
        }
        public string InvestorInformation()
        {
            return $"The investor {FullName} with a broker {BrokerName} has stocks:\n{string.Join("\n",Portfolio)}";
        }
    }
}