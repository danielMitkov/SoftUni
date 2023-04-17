int n = int.Parse(Console.ReadLine());
HashSet<string> set = new();
for(int i = 0;i<n;i++) set.Add(Console.ReadLine());
Console.Write(string.Join("\n", set));