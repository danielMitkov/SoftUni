using System;
using System.Linq;
namespace DefiningClasses;
public class StartUp {
    public static void Main() {
        Family family = new Family();
        for(int n = int.Parse(Console.ReadLine());n > 0;n--) {
            string[] data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            int age = int.Parse(data[1]);
            family.People.Add(new Person() { Name = name,Age = age });
        }
        foreach(var person in family.People.Where(x => x.Age > 30).OrderBy(x => x.Name)) {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}