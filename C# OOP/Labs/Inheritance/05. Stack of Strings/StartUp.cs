namespace CustomStack;
public class StartUp
{
    public static void Main()
    {
        StackOfStrings stack = new();
        stack.AddRange(new string[] {"bob","john"});
        foreach(var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}