namespace WildFarm.Animals.Mammals.Felines;
public class Tiger:Feline
{
    public Tiger(string name,double weight,string livingRegion,string breed)
        : base(name,weight,livingRegion,breed)
    {
        WeightGain = 1.00;
        Eats = "Meat";
    }
    public override string AskForFood() => "ROAR!!!";
}