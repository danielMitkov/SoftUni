using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var people = new List<Person>();
        while (true) {
            var data = Console.ReadLine().Split();
            if (data[0] == "End") break;
            Person obj = people.Find(x => x.Id == data[1]);
            if (obj != null) {
                obj.Name = data[0];
                obj.Age = int.Parse(data[2]);
            } else {
                people.Add(new Person(data[0], data[1], int.Parse(data[2])));
            }
        }
        Console.Write(String.Join("\n", people.OrderBy(x => x.Age)));
    }
}
class Person {
    public Person(string name, string id, int age) {
        Name = name;
        Id = id;
        Age = age;
    }
    public string Name { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }
    public override string ToString() {
        return $"{Name} with ID: {Id} is {Age} years old.";
    }
}