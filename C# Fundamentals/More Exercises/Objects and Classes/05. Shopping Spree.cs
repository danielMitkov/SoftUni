using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var dataPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        var people = new List<Person>();
        foreach (var person in dataPeople) {
            string[] data = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
            people.Add(new Person(data[0], decimal.Parse(data[1])));
        }
        var dataProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
        var products = new List<Product>();
        foreach (var product in dataProducts) {
            string[] data = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
            products.Add(new Product(data[0], decimal.Parse(data[1])));
        }
        while (true) {
            string[] data = { Console.ReadLine() };
            if (data[0] == "END") break;
            data = data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var person = people.Find(x => x.Name == data[0]);
            if (person != null) {
                var product = products.Find(x => x.Name == data[1]);
                if (product != null) {
                    if (person.Money >= product.Cost) {
                        person.Money -= product.Cost;
                        person.Bag.Add(product);
                        Console.WriteLine($"{person} bought {product}");
                    } else {
                        Console.WriteLine($"{person} can't afford {product}");
                    }
                }
            }
        }
        foreach (var person in people) {
            Console.Write($"{person} - ");
            if (person.Bag.Count > 0) {
                Console.WriteLine(String.Join(", ", person.Bag));
            } else {
                Console.WriteLine("Nothing bought");
            }
        }
    }
}
class Person {
    public Person(string name, decimal money) {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }
    public string Name { get; set; }
    public decimal Money { get; set; }
    public List<Product> Bag { get; set; }
    public override string ToString() {
        return Name;
    }
}
class Product {
    public Product(string name, decimal cost) {
        Name = name;
        Cost = cost;
    }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public override string ToString() {
        return Name;
    }
}