namespace Heroes.Models.Weapons
{
    public class Mace:Weapon
    {
        public Mace(string name,int durability) : base(name,durability)
        {
        }
        public override int DoDamage()
        {
            Durability--;
            if(Durability > 0)
            {
                return 25;
            }
            return 0;
        }
    }
}
