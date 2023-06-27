namespace ShoppingSpree;
public class Product
{
    private string name;
    private double cost;
    public string Name
    {
        get => name;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }
    public double Cost
    {
        get => cost;
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }
    public Product(string name,double cost)
    {
        Name = name;
        Cost = cost;
    }
}