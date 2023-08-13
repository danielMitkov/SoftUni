namespace Heroes.Models.Weapons
{
    public class Claymore:Weapon
    {
        public Claymore(string name,int durability) : base(name,durability)
        {
        }
        public override int DoDamage()
        {
            Durability--;
            if(Durability > 0)
            {
                return 20;
            }
            return 0;
        }
    }
}
