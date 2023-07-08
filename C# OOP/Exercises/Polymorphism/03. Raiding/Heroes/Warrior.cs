namespace Raiding.Heroes;
public class Warrior:Hero
{
    public Warrior(string name) : base(name,100)
    {
    }
    public override string CastAbility() => $"{GetType().Name} - {Name} hit for {Power} damage";
}