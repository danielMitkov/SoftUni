using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name,int openPositions,char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }
        public int Count { get => Players.Count; }
        public string AddPlayer(Player player)
        {
            if(player.Name == null || player.Name == string.Empty || player.Position == null || player.Position == string.Empty)
            {
                return "Invalid player's information.";
            }
            if(OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if(player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            Players.Add(player);
            OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }
        public bool RemovePlayer(string name)
        {
            int index = Players.FindIndex(x=>x.Name == name);
            if(index == -1)
            {
                return false;
            }
            Players.RemoveAt(index);
            OpenPositions++;
            return true;
        }
        public int RemovePlayerByPosition(string position)
        {
            int removed = Players.RemoveAll(x=>x.Position == position);
            OpenPositions += removed;
            return removed;
        }
        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);
            if(player != null)
            {
                player.Retired = true;
            }
            return player;
        }
        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(x=>x.Games >= games).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            sb.Append(string.Join(Environment.NewLine,Players.Where(x=>x.Retired == false)));
            return sb.ToString();
        }
    }
}
