int target = int.Parse(Console.ReadLine());
Console.Write(string.Join("\n",Console.ReadLine().Split().Where(x => x.Length<=target)));
