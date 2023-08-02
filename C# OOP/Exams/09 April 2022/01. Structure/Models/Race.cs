using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
namespace Formula1.Models
{
    public class Race:IRace
    {
        private string raceName;
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                raceName = value;
            }
        }
        private int numberOfLaps;
        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }
        public bool TookPlace { get; set; }
        private List<IPilot> pilots = new List<IPilot>();
        public ICollection<IPilot> Pilots => pilots.AsReadOnly();
        public Race(string raceName,int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
        }
        public void AddPilot(IPilot pilot) => Pilots.Add(pilot);
        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.Append("Took place: ");
            if(TookPlace)
            {
                sb.Append("Yes");
            }
            else
            {
                sb.Append("No");
            }
            return sb.ToString();
        }
    }
}
