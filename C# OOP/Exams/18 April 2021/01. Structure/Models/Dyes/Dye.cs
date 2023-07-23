using Easter.Models.Dyes.Contracts;
namespace Easter.Models.Dyes
{
    public class Dye:IDye
    {
        private int power;
        public int Power
        {
            get { return power; }
            private set
            {
                if(value < 0)
                {
                    power = 0;
                }
                else
                {
                    power = value;
                }
            }
        }
        public Dye(int power)
        {
            Power = power;
        }
        public bool IsFinished() => Power == 0;
        public void Use()
        {
            Power -= 10;
            if(Power < 0)
            {
                Power = 0;
            }
        }
    }
}
