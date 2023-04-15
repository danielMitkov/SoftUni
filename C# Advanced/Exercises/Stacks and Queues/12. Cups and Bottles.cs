Queue<int> cups = new(Console.ReadLine().Split().Select(int.Parse));
Stack<int> bottles = new(Console.ReadLine().Split().Select(int.Parse));
int wasted = 0;
int currentCup = cups.Peek();
while(cups.Any() && bottles.Any())
{
    int diff = currentCup - bottles.Pop();
    if(diff <= 0)
    {
        cups.Dequeue();
        wasted += Math.Abs(diff);
        if(cups.Any())
        {
            currentCup = cups.Peek();
        }
    }
    else
    {
        currentCup = diff;
    }
}
if(!cups.Any())
{
    Console.WriteLine($"Bottles: {string.Join(' ',bottles)}");
}
if(!bottles.Any())
{
    Console.WriteLine($"Cups: {string.Join(' ',cups)}");
}
Console.WriteLine($"Wasted litters of water: {wasted}");