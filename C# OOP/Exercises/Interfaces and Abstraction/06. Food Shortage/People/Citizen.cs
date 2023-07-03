namespace FoodShortage.People;
public class Citizen:Person
{
    public override void BuyFood() => Food += 10;
}