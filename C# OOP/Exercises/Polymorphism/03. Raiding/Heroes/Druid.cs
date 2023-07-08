namespace Raiding.Heroes;
public class Druid:Hero
{
    public Druid(string name) : base(name,80)
    {
    }
    public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";
}