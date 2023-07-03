namespace MilitaryElite.Soldiers;
public class Private : Soldier
{
    public decimal Salary { get; protected set; }
    public Private(string id,string fullName,decimal salary) : base(id,fullName)
    {
        Salary = salary;
    }
    public override string ToString() => $"{base.ToString()} Salary: {Salary:F2}";
}