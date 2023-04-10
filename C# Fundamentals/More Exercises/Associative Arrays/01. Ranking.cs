using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var contests = new Dictionary<string, string>();
        var students = new Dictionary<string, Dictionary<string, int>>();
        string line;
        while ((line = Console.ReadLine()) != "end of contests")
        {
            var data = line.Split(':');
            if (!contests.ContainsKey(data[0])) contests[data[0]] = data[1];
        }
        while ((line = Console.ReadLine()) != "end of submissions")
        {
            var data = line.Split("=>");
            var contest = data[0];
            var pass = data[1];
            var student = data[2];
            var score = int.Parse(data[3]);
            if (!contests.ContainsKey(contest) || contests[contest] != pass)
            {
                continue;
            }
            if (!students.ContainsKey(student))
            {
                students[student] = new Dictionary<string, int>();
            }
            if (!students[student].ContainsKey(contest))
            {
                students[student][contest] = score;
            }
            if (score > students[student][contest])
            {
                students[student][contest] = score;
            }
        }
        var best = students.OrderBy(x => x.Value.Sum(x => x.Value)).Last();
        Console.WriteLine($"Best candidate is {best.Key} with total {best.Value.Sum(x => x.Value)} points.");
        Console.WriteLine("Ranking:");
        foreach (var nameDic in students.OrderBy(x => x.Key))
        {
            Console.WriteLine(nameDic.Key);
            foreach (var contestScore in nameDic.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {contestScore.Key} -> {contestScore.Value}");
            }
        }
    }
}