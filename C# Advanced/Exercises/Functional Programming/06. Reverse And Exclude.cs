var nums = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
int target = int.Parse(Console.ReadLine());
Console.Write(string.Join(" ",nums.Where(x => x%target!=0)));
