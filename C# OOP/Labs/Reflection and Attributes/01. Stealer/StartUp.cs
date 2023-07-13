namespace Stealer;
public class StartUp
{
    public static void Main()
    {
        Spy spy = new();
        string result = spy.StealFieldInfo("Stealer.Hacker","username","password");
        Console.WriteLine(result);
    }
}