using System.Linq;
using System;
public class Program
{
    public static void Main()
    {
        int[] field = new int[int.Parse(Console.ReadLine())];
        int[] positions = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        foreach(int pos in positions)
        {
            if(pos < 0 || pos >= field.Length)
            {
                continue;
            }
            field[pos] = 1;
        }
        string input = string.Empty;
        while((input = Console.ReadLine()) != "end")
        {
            string[] data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            long pos = long.Parse(data[0]);
            string move = data[1];
            long distance = long.Parse(data[2]);
            if(pos < 0 || pos >= field.Length || field[pos] == 0)
            {
                continue;
            }
            field[pos] = 0;
            do
            {
                if(move == "left")
                {
                    pos -= distance;
                }
                if(move == "right")
                {
                    pos += distance;
                }
                if(pos < 0 || pos >= field.Length)
                {
                    break;
                }
            } while(field[pos] == 1);
            if(pos >= 0 && pos < field.Length)
            {
                field[pos] = 1;
            }
        }
        Console.Write(string.Join(' ',field));
    }
}