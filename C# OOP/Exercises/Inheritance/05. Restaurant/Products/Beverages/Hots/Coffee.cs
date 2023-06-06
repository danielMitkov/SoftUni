namespace Restaurant.Products.Beverages.Hots;
public class Coffee:HotBeverage
{
    public double Caffeine { get; set; }
    public Coffee(string name,double caffeine) : base(name,50,3.5)
    {
        Caffeine = caffeine;
    }
}