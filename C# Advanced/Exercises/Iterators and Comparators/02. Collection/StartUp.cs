namespace Listy_Iterator;
public class StartUp
{
    public static void Main()
    {
        string[] create = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
        ListyIterator<string> iterator = new(create[1..]);
        string input = string.Empty;
        while((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if(data[0] == "Move")
            {
                Console.WriteLine(iterator.Move());
            }
            if(data[0] == "Print")
            {
                iterator.Print();
            }
            if(data[0] == "HasNext")
            {
                Console.WriteLine(iterator.HasNext());
            }
            if(data[0] == "PrintAll")
            {
                foreach(var item in iterator)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}