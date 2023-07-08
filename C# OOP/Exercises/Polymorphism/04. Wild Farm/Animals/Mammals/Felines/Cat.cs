namespace WildFarm.Animals.Mammals.Felines;
public class Cat:Feline
{
    public Cat(string name,double weight,string livingRegion,string breed)
        : base(name,weight,livingRegion,breed)
    {
        WeightGain = 0.30;
        Eats = "Vegetable,Meat";
    }
    public override string AskForFood() => "Meow";
}