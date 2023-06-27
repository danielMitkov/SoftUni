namespace PizzaCalories;
public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    public string Name
    {
        get => name;
        private set
        {
            if(value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
    public Pizza(string name,string flour,string baking,decimal grams)
    {
        Name = name;
        dough = new(flour,baking,grams);
        toppings = new();
    }
    public decimal Calories => dough.Calories + toppings.Sum(x=>x.Calories);
    public void AddTopping(string type,decimal grams)
    {
        toppings.Add(new Topping(type,grams));
    }
    public void CheckToppings()
    {
        if(toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }
}