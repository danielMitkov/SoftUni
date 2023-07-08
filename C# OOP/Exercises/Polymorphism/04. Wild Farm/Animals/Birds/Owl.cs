namespace WildFarm.Animals.Birds;
public class Owl:Bird
{
    public Owl(string name,double weight,double wingSize)
        : base(name,weight,wingSize)
    {
        WeightGain = 0.25;
        Eats = "Meat";
    }
    public override string AskForFood() => "Hoot Hoot";
}