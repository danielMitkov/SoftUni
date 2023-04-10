using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var list = new List<Human>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var data = Console.ReadLine().Split();
            list.Add(new Human(data[0], int.Parse(data[1])));
        }
        Console.Write(list.Find(x => x.Age == list.Max(x => x.Age)));
    }
}
class Human {
    public Human(string name, int age) {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public override string ToString() {
        return $"{Name} {Age}";
    }
}