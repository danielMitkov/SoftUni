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
            students.Add(new Student(data[0], data[1], data[2], data[3]));
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
    public Student(string first, string last, string age, string town) {
        FirstName = first;
        LastName = last;
        Age = age;
        Town = town;
    }
}