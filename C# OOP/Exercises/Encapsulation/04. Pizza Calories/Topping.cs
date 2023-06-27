namespace PizzaCalories;
public class Topping
{
    private decimal grams;
    private decimal mod;
    public Topping(string type,decimal grams)
    {
        switch(type.ToLower())
        {
            case "meat":
                mod = 1.2m;
                break;
            case "veggies":
                mod = 0.8m;
                break;
            case "cheese":
                mod = 1.1m;
                break;
            case "sauce":
                mod = 0.9m;
                break;
            default:
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
        }
        if(grams < 1 || grams > 50)
        {
            throw new ArgumentException($"{type} weight should be in the range [1..50].");
        }
        this.grams = grams;
    }
    public decimal Calories => 2 * grams * mod;
}