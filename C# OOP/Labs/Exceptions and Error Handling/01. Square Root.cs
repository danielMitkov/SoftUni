try
{
    int num = int.Parse(Console.ReadLine());
    if(num < 0)
    {
        throw new ArgumentException("Invalid number.");
    }
    Console.WriteLine(Math.Sqrt(num));
}
catch(ArgumentException err)
{
    Console.WriteLine(err.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}
