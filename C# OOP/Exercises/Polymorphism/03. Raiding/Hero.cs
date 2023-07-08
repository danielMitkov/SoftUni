namespace Raiding;
public abstract class Hero
{
    public string Name { get; private set; }
    public int Power { get; private set; }
    protected Hero(string name,int power)
    {
        Name = name;
        Power = power;
    }
    public abstract string CastAbility();
}