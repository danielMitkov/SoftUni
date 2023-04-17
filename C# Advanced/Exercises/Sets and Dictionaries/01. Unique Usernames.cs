HashSet<string> names = new();
for(int n = int.Parse(Console.ReadLine());n>0;--n) names.Add(Console.ReadLine());
foreach(var name in names) Console.WriteLine(name);