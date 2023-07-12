string[] input = Console.ReadLine().Split(' ');
int sum = 0;
foreach(string data in input)
{
    try
    {
        sum += int.Parse(data);
    }
    catch(FormatException)
    {
        Console.WriteLine($"The element '{data}' is in wrong format!");
    }
    catch(OverflowException)
    {
        Console.WriteLine($"The element '{data}' is out of range!");
    }
    Console.WriteLine($"Element '{data}' processed - current sum: {sum}");
}
Console.WriteLine($"The total sum of all integers is: {sum}");
