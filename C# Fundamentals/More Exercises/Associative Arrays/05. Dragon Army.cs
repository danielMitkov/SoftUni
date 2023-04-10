using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni
{
    static void Main()
    {
        var types = new Dictionary<string, Dictionary<string, Dragon>>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n)
        {
            var data = Console.ReadLine().Split(" ");
            var type = data[0];
            var dragon = data[1];
            var dmg = data[2] == "null" ? 45 : int.Parse(data[2]);
            var hp = data[3] == "null" ? 250 : int.Parse(data[3]);
            var armor = data[4] == "null" ? 10 : int.Parse(data[4]);
            if (!types.ContainsKey(type))
            {
                types[type] = new Dictionary<string, Dragon>();
            }
            if (!types[type].ContainsKey(dragon))
            {
                types[type][dragon] = new Dragon(dmg, hp, armor);
            }
            if (types[type].ContainsKey(dragon))
            {
                types[type][dragon] = new Dragon(dmg, hp, armor);
            }
        }
        foreach (var typeDic in types)
        {
            var avgDmg = typeDic.Value.Average(x => x.Value.Dmg);
            var avgHp = typeDic.Value.Average(x => x.Value.Hp);
            var avgArmor = typeDic.Value.Average(x => x.Value.Armor);
            Console.WriteLine($"{typeDic.Key}::({avgDmg:f2}/{avgHp:f2}/{avgArmor:f2})");
            foreach (var nameDDragon in typeDic.Value.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-{nameDDragon.Key}" + nameDDragon.Value);
            }
        }
    }
}
class Dragon
{
    public Dragon(int dmg, int hp, int armor)
    {
        Dmg = dmg;
        Hp = hp;
        Armor = armor;
    }
    public int Dmg { get; set; }
    public int Hp { get; set; }
    public int Armor { get; set; }
    public override string ToString()
    {
        return $" -> damage: {Dmg}, health: {Hp}, armor: {Armor}";
    }
}