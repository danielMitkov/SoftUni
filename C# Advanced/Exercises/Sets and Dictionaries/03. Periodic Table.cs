SortedSet<string> set = new();
for(int n = int.Parse(Console.ReadLine());n>0;n--) set.UnionWith(Console.ReadLine().Split());
Console.Write(string.Join(' ',set));