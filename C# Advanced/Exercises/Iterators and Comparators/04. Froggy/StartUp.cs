public class StartUp
{
    public static void Main()
    {
        Lake lake = new(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Console.Write(string.Join(", ",lake));
    }
}