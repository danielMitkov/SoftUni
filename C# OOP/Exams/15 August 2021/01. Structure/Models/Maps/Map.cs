using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
namespace CarRacing.Models.Maps
{
    public class Map:IMap
    {
        public string StartRace(IRacer racerOne,IRacer racerTwo)
        {
            if(!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }
            if(racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            if(racerTwo.IsAvailable() && !racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            racerOne.Race();
            racerTwo.Race();
            double oneMulti = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double twoMulti = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            double oneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * oneMulti;
            double twoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * twoMulti;
            IRacer winner = null;
            if(oneChance > twoChance)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }
            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
