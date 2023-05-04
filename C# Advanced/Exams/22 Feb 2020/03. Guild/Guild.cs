using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => roster.Count; }

        private List<Player> roster;

        public Guild(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            if(roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x=>x.Name == name);
            if(player != null)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x=>x.Name == name);
            if(player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            if(player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)//POSSIBLE ERROR
        {
            List<Player> players = roster.FindAll(x => x.Class == @class);
            roster.RemoveAll(x=>x.Class == @class);
            return players.ToArray();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach(var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
