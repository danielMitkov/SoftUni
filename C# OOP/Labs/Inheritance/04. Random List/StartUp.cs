namespace CustomRandomList;
public class StartUp
{
    public static void Main(string[] args)
    {
        RandomList list = new()
        {
            "bob",
            "john",
            "peter",
        };
        Console.WriteLine(list.RandomString());
    }
}