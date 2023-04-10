using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var lists = new List<List<Human>>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var data = Console.ReadLine().Split();
            bool added = false;
            foreach (var list in lists) {
                if (list[0].Department == data[2]) {
                    list.Add(new Human(data[0], decimal.Parse(data[1]), data[2]));
                    added = true;
                }
            }
            if (!added) {
                lists.Add(new List<Human>() { new Human(data[0], decimal.Parse(data[1]), data[2]) });
            }
        }
        var winner = new List<Human>();
        var maxAvg = decimal.MinValue;
        foreach (var list in lists) {
            var avg = 0m;
            foreach (var human in list) {
                avg += human.Salary;
            }
            avg = avg / list.Count;
            if (avg > maxAvg) {
                maxAvg = avg;
                winner = list;
            }
        }
        Console.WriteLine($"Highest Average Salary: {winner[0].Department}");
        Console.Write(String.Join("\n", winner.OrderByDescending(x => x.Salary)));
    }
}
class Human {
    public Human(string name, decimal salary, string department) {
        Name = name;
        Salary = salary;
        Department = department;
    }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public override string ToString() {
        return $"{Name} {Salary:f2}";
    }
}