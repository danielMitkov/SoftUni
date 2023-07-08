namespace WildFarm.Animals.Mammals;
public class Dog:Mammal
{
    public Dog(string name,double weight,string livingRegion)
        : base(name,weight,livingRegion)
    {
        WeightGain = 0.40;
        Eats = "Meat";
    }
    public override string AskForFood() => "Woof!";
}