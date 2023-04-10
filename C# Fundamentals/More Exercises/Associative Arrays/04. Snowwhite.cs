using System.Collections.Generic;
using System.Linq;
using System;
class Dwarf
{
    public string Name { get; set; }
    public string HatColor { get; set; }
    public int Physics { get; set; }
    public Dwarf(string name,string hat,int physics)
    {
        Name = name;
        HatColor = hat;
        Physics = physics;
    }
}
public class StartUp
{
    public static void Main()
    {
        List<Dwarf> dwarves = new List<Dwarf>();
        Dictionary<string,int> colors = new Dictionary<string,int>();
        string input;
        while((input = Console.ReadLine()) != "Once upon a time")
        {
            string[] tokens = input.Split(" <:> ");
            string name = tokens[0];
            string color = tokens[1];
            int physics = int.Parse(tokens[2]);
            Dwarf dwarf = dwarves.FirstOrDefault(x => x.Name == name && x.HatColor == color);
            if(dwarf != null)
            {
                if(physics > dwarf.Physics)
                {
                    dwarf.Physics = physics;
                }
                continue;
            }
            dwarves.Add(new Dwarf(name,color,physics));
            if(!colors.ContainsKey(color))
            {
                colors.Add(color,0);
            }
            colors[color]++;
        }
        foreach(Dwarf dwarf in dwarves.OrderByDescending(x=>x.Physics)
            .ThenByDescending(x => colors[x.HatColor]))
        {
            Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
        }
    }
}