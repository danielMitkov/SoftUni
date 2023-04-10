using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var list = new List<Student>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var line = Console.ReadLine().Split(" ").ToList();
            list.Add(new Student(line[0], line[1], decimal.Parse(line[2])));
        }
        list = list.OrderByDescending(x => x.Grade).ToList();
        Console.Write(String.Join("\n", list));

    }
}
class Student {
    public Student(string first, string last, decimal grade) {
        FirstName = first;
        LastName = last;
        Grade = grade;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Grade { get; set; }
    public override string ToString() {
        return $"{FirstName} {LastName}: {Grade}";
    }
}