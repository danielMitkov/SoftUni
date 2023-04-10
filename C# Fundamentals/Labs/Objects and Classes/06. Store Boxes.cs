using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var boxs = new List<Box>();
        while (true) {
            string line = Console.ReadLine();
            if (line == "end") break;
            var data = line.Split(' ');
            boxs.Add(new Box(data[0], data[1], int.Parse(data[2]), decimal.Parse(data[3])));
        }
        boxs.OrderByDescending(x => x.Cost).ToList().ForEach(x => Console.WriteLine($"{x.Id}\n-- {x.Item.Name} - ${x.Item.Cost:f2}: {x.N}\n-- ${x.Cost:f2}"));
    }
}
class Item {
    public string Name { get; set; }
    public decimal Cost { get; set; }
}
class Box {
    public string Id { get; set; }
    public Item Item { get; set; }
    public int N { get; set; }
    public decimal Cost { get { return N * Item.Cost; } }
    public Box(string id, string name, int n, decimal cost) {
        Id = id;
        Item = new Item();
        Item.Name = name;
        N = n;
        Item.Cost = cost;
    }
}