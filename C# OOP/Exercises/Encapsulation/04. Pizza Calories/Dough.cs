namespace PizzaCalories;
public class Dough
{
    private decimal modFlour;
    private decimal modBaking;
    private decimal grams;
    public Dough(string flour,string baking,decimal grams)
    {
        switch(flour.ToLower())
        {
            case "white":
                modFlour = 1.5m;
                break;
            case "wholegrain":
                modFlour = 1.0m;
                break;
            default:
                throw new ArgumentException("Invalid type of dough.");
        }
        switch(baking.ToLower())
        {
            case "chewy":
                modBaking = 1.1m;
                break;
            case "crispy":
                modBaking = 0.9m;
                break;
            case "homemade":
                modBaking = 1.0m;
                break;
            default:
                throw new ArgumentException("Invalid type of dough.");
        }
        if(grams < 1 || grams > 200)
        {
            throw new ArgumentException("Dough weight should be in the range [1..200].");
        }
        this.grams = grams;
    }
    public decimal Calories => 2 * grams * modFlour * modBaking;
}