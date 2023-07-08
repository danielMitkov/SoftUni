namespace WildFarm;
public abstract class Animal
{
    public string Name { get; protected set; }
    public double Weight { get; protected set; }
    public double WeightGain { get; protected set; }
    public int FoodEaten { get; protected set; }
    public string Eats { get; protected set; }
    protected Animal(string name,double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }
    public abstract string AskForFood();
    public void Eat(string foodType,int quantity)
    {
        if(Eats.Contains(foodType))
        {
            FoodEaten += quantity;
            Weight += WeightGain * quantity;
        }
        else
        {
            throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
        }
    }
}