namespace Stealer;
public class StartUp
{
    public static void Main()
    {
        Spy spy = new();
        string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
        Console.WriteLine(result);
    }
}