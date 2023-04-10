using System;
public class Program
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        for(int n = 1; n <= num;++n)
        {
            for(int m = 1; m <= n; ++m)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
    }
}