namespace WildFarm;
public abstract class Food
{
    public int Quantity { get; protected set; }
    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}