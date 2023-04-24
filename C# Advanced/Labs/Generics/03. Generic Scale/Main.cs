namespace GenericScale;
public class StartUp
{
    public static void Main()
    {
        EqualityScale<int> comparer = new(1,1);
        Console.Write(comparer.AreEqual());
    }
}