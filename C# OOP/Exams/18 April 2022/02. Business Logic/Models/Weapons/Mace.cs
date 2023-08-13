namespace Heroes.Models.Weapons
{
    public class Mace:Weapon
    {
        public Mace(string name,int durability) : base(name,durability)
        {
        }
        public override int DoDamage()
        {
            if(Durability - 1 >= 0)
            {
                Durability--;
                return 25;
            }
            return 0;
        }
    }
}
