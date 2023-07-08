namespace WildFarm.Animals.Mammals;
public class Mouse:Mammal
{
    public Mouse(string name,double weight,string livingRegion)
        : base(name,weight,livingRegion)
    {
        WeightGain = 0.10;
        Eats = "Vegetable,Fruit";
    }
    public override string AskForFood() => "Squeak";
}