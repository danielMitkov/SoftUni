namespace ValidationAttributes;
public class StartUp
{
    public static void Main()
    {
        Person person = new(null,-1);
        Console.WriteLine(Validator.IsValid(person));
    }
}