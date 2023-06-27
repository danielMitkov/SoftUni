namespace ShoppingSpree;
public class Person
{
    private string name;
    private double money;
    private List<Product> bag;
    public string TryAddProduct(Product product)
    {
        if(money >= product.Cost)
        {
            money -= product.Cost;
            bag.Add(product);
            return $"{name} bought {product.Name}";
        }
        return $"{name} can't afford {product.Name}";
    }
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
    public double Money
    {
        get => money;
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }
    public IReadOnlyList<Product> Bag => bag.AsReadOnly();
    public Person(string name,double money)
    {
        Name = name;
        Money = money;
        bag = new();
    }
}