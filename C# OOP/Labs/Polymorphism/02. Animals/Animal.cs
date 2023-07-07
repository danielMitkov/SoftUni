namespace Animals;
public class Animal
{
    protected string name;
    protected string favouriteFood;
    public Animal(string name,string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }
    public virtual string ExplainSelf() => $"I am {name} and my fovourite food is {favouriteFood}";
}