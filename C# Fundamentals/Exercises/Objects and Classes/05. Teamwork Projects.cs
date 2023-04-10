using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static List<Team> teams = new List<Team>();
    static void Main() {
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var data = Console.ReadLine().Split("-");
            CheckAdd(data[0], data[1]);
        }
        while (true) {
            var line = Console.ReadLine();
            if (line == "end of assignment") break;
            var data = line.Split("->");
            CheckJoin(data[0], data[1]);
        }
        Print();
    }
    static void CheckAdd(string creator, string name) {
        if (teams.Any(x => x.Name == name)) {
            Console.WriteLine($"Team {name} was already created!");
        } else if (teams.Any(x => x.Creator == creator)) {
            Console.WriteLine($"{creator} cannot create another team!");
        } else {
            teams.Add(new Team(creator, name));
            Console.WriteLine($"Team {name} has been created by {creator}!");
        }
    }
    static void CheckJoin(string member, string name) {
        if (!teams.Any(x => x.Name == name)) {
            Console.WriteLine($"Team {name} does not exist!");
        } else if (teams.Any(x => x.Users.Contains(member) || x.Creator == member)) {
            Console.WriteLine($"Member {member} cannot join team {name}!");
        } else {
            teams.Find(x => x.Name == name).Users.Add(member);
        }
    }
    static void Print() {
        var disbanded = teams.Where(x => x.Users.Count == 0).OrderBy(x => x.Name).ToList();
        teams = teams.Where(x => x.Users.Count > 0).ToList();
        teams = teams.OrderByDescending(x => x.Users.Count).ThenBy(x => x.Name).ToList();
        teams.ForEach(x => x.Users.Sort());
        foreach (var obj in teams) {
            Console.WriteLine($"{obj.Name}\n- {obj.Creator}");
            foreach (var str in obj.Users) {
                Console.WriteLine($"-- {str}");
            }
        }
        Console.WriteLine("Teams to disband:");
        Console.Write(String.Join("\n", disbanded));
    }
}
class Team {
    public Team(string creator, string name) {
        Creator = creator;
        Name = name;
    }
    public List<string> Users { get; set; } = new List<string>();
    public string Name { get; private set; }
    public string Creator { get; private set; }
    public override string ToString() {
        return Name;
    }
}