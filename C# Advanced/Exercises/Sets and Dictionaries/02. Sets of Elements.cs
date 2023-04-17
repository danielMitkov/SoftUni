HashSet<decimal> n = new();
HashSet<decimal> m = new();
int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
for(int i = sizes[0];i>0;--i) n.Add(decimal.Parse(Console.ReadLine()));
for(int i = sizes[1];i>0;--i) m.Add(decimal.Parse(Console.ReadLine()));
n.IntersectWith(m);
Console.Write(string.Join(' ',n));