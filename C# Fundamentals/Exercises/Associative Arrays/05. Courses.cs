using System;
using System.Collections.Generic;
using System.Linq;
class Program {
    static void Main() {
        var courses = new Dictionary<string, List<string>>();
        while (true) {
            string[] data = { Console.ReadLine() };
            if (data[0] == "end") break;
            data = data[0].Split(" : ");
            if (courses.ContainsKey(data[0])) {
                courses[data[0]].Add(data[1]);
            } else {
                courses[data[0]] = new List<string>() { data[1] };
            }
        }
        foreach (var kvp in courses) {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
            foreach (var student in kvp.Value) {
                Console.WriteLine($"-- {student}");
            }
        }
    }
}