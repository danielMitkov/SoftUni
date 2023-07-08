namespace WildFarm.Animals.Birds;
public class Hen:Bird
{
    public Hen(string name,double weight,double wingSize)
        : base(name,weight,wingSize)
    {
        WeightGain = 0.35;
        Eats = "Vegetable,Fruit,Meat,Seeds";
    }
    public override string AskForFood() => "Cluck";
}