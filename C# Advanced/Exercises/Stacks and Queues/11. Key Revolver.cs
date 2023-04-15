int bulletCost = int.Parse(Console.ReadLine());
int magazineSize = int.Parse(Console.ReadLine());
Stack<int> bullets = new(Console.ReadLine().Split().Select(int.Parse));
Queue<int> locks = new(Console.ReadLine().Split().Select(int.Parse));
int cash = int.Parse(Console.ReadLine());
int magazineTimer = 0;
while(bullets.Any())
{
    if(magazineTimer == magazineSize)
    {
        Console.WriteLine("Reloading!");
        magazineTimer = 0;
        continue;
    }
    if(!locks.Any())
    {
        break;
    }
    if(bullets.Pop() <= locks.Peek())
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }
    magazineTimer++;
    cash -= bulletCost;
}
if(!locks.Any())
{
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${cash}");
    return;
}
if(!bullets.Any())
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}