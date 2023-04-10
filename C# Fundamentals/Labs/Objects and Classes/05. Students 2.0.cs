using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var students = new List<Student>();
        while (true) {
            string line = Console.ReadLine();
            if (line == "end") break;
            var data = line.Split();
            students = students.Where(x => x.FirstName != data[0] || x.LastName != data[1]).ToList();
            students.Add(new Student() { FirstName = data[0], LastName = data[1], Age = data[2], Town = data[3] });
        }
        string city = Console.ReadLine();
        students.Where(x => x.Town == city).ToList().ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} is {x.Age} years old."));
    }
}
class Student {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Age { get; set; }
    public string Town { get; set; }
}