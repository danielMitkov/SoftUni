using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;
namespace Easter.Models.Workshops
{
    public class Workshop:IWorkshop
    {
        public void Color(IEgg egg,IBunny bunny)
        {
            while(bunny.Energy > 0 && !egg.IsDone() && bunny.Dyes.Any(x => !x.IsFinished()))
            {
                IDye dye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
                dye.Use();
                egg.GetColored();
                bunny.Work();
            }
        }
    }
}
