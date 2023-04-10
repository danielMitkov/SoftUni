using System;
public class Program
{
    public static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int sum = 0;
        for(int num = start; num <= end;++num)
        {
            Console.Write(num + " ");
            sum += num;
        }
        Console.Write($"{Environment.NewLine}Sum: {sum}");
    }
}