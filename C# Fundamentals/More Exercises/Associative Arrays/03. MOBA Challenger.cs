using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var users = new Dictionary<string, Dictionary<string, int>>();
        string line;
        while ((line = Console.ReadLine()) != "Season end")
        {
            var data = line.Split(" ");
            if (data[1] == "->")
            {
                data = line.Split(" -> ");
                var user = data[0];
                var pos = data[1];
                var skill = int.Parse(data[2]);
                if (!users.ContainsKey(user))
                {
                    users[user] = new Dictionary<string, int>();
                }
                if (!users[user].ContainsKey(pos))
                {
                    users[user][pos] = skill;
                }
                if (skill > users[user][pos])
                {
                    users[user][pos] = skill;
                }
            }
            else
            {
                data = line.Split(" vs ");
                var user1 = data[0];
                var user2 = data[1];
                if (!users.ContainsKey(user1)) continue;
                if (!users.ContainsKey(user2)) continue;
                int sum1 = 0;
                int sum2 = 0;
                foreach (var posSkill in users[user1])
                {
                    if (users[user2].ContainsKey(posSkill.Key))
                    {
                        sum1 += posSkill.Value;
                        sum2 += users[user2][posSkill.Key];
                    }
                }
                if (sum1 > sum2)
                {
                    users.Remove(user2);
                }
                if (sum2 > sum1)
                {
                    users.Remove(user1);
                }
            }
        }
        foreach (var nameDic in users.OrderByDescending(x => x.Value.Sum(x => x.Value))
            .ThenBy(x => x.Key))
        {
            Console.WriteLine($"{nameDic.Key}: {nameDic.Value.Sum(x => x.Value)} skill");
            foreach (var posSkill in nameDic.Value.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"- {posSkill.Key} <::> {posSkill.Value}");
            }
        }
    }
}