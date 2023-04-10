using System;
using System.Collections.Generic;
using System.Linq;
class Program {
    static void Main() {
        var students = new Dictionary<string, List<double>>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var name = Console.ReadLine();
            var grade = double.Parse(Console.ReadLine());
            if (!students.ContainsKey(name)) students[name] = new List<double>();
            students[name].Add(grade);
        }
        foreach (var kvp in students.Where(x => x.Value.Average() >= 4.5)) {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
        }
    }
}