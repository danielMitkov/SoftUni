namespace Easter.Models.Bunnies
{
    public class SleepyBunny:Bunny
    {
        public SleepyBunny(string name) : base(name,50)
        {
        }
        public override void Work()
        {
            Energy -= 15;
            if(Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
