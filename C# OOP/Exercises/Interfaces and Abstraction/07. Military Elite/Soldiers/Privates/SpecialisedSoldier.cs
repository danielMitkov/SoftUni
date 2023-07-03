namespace MilitaryElite.Soldiers.Privates;
public abstract class SpecialisedSoldier:Private
{
    protected string corps;
    public string Corps
    {
        get => corps;
        protected set
        {
            if(value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException("invalid corps");
            }
            corps = value;
        }
    }
    protected SpecialisedSoldier(string id,string fullName,decimal salary,string corps)
        : base(id,fullName,salary)
    {
        Corps = corps;
    }
    public override string ToString() => $"{base.ToString()}{Environment.NewLine}Corps: {Corps}";
}