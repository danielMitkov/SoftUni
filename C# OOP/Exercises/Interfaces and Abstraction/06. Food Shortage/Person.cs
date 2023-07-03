namespace FoodShortage;
public abstract class Person:IBuyer
{
    public int Food { get; protected set; }
    public abstract void BuyFood();
}