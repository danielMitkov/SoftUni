namespace Heroes.Models.Weapons
{
    public class Claymore:Weapon
    {
        public Claymore(string name,int durability) : base(name,durability)
        {
        }
        public override int DoDamage()
        {
            if(Durability - 1 >= 0)
            {
                Durability--;
                return 20;
            }
            return 0;
        }
    }
}
