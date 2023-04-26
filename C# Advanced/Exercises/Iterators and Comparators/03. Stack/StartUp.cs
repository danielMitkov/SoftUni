namespace Custom_Stack;
public class StartUp
{
    public static void Main()
    {
        CustomStack<string> stck = new();
        string input = string.Empty;
        while((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(new string[] { " ","," },StringSplitOptions.RemoveEmptyEntries);
            if(data[0] == "Push")
            {
                stck.Push(data[1..]);
            }
            if(data[0] == "Pop")
            {
                stck.Pop();
            }
        }
        foreach(string item in stck)
        {
            Console.WriteLine(item);
        }
        foreach(string item in stck)
        {
            Console.WriteLine(item);
        }
    }
}