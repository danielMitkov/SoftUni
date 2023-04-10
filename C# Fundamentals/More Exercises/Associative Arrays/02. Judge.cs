using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var contests = new Dictionary<string, Dictionary<string, int>>();
        string line;
        while ((line = Console.ReadLine()) != "no more time")
        {
            var data = line.Split(" -> ");
            var user = data[0];
            var contest = data[1];
            var points = int.Parse(data[2]);
            if (!contests.ContainsKey(contest))
            {
                contests[contest] = new Dictionary<string, int>();
            }
            if (!contests[contest].ContainsKey(user))
            {
                contests[contest][user] = points;
            }
            if (points > contests[contest][user])
            {
                contests[contest][user] = points;
            }
        }
        foreach (var contest in contests)
        {
            Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
            int pos = 1;
            foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pos}. {user.Key} <::> {user.Value}");
                pos++;
            }
        }
        Console.WriteLine("Individual standings:");
        var users = new Dictionary<string, int>();
        foreach (var contest in contests)
        {
            foreach (var user in contest.Value)
            {
                if (!users.ContainsKey(user.Key))
                {
                    users[user.Key] = user.Value;
                    continue;
                }
                users[user.Key] += user.Value;
            }
        }
        int poss = 1;
        foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{poss}. {user.Key} -> {user.Value}");
            poss++;
        }
    }
}