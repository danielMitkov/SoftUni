using System;
public class Program
{
    public static void Main()
    {
        int[] divisors = { 10,7,6,3,2 };
        int num = int.Parse(Console.ReadLine());
        for(int i = 0;i < divisors.Length;i++)
        {
            if(num % divisors[i] == 0)
            {
                Console.Write($"The number is divisible by {divisors[i]}");
                return;
            }
        }
        Console.Write("Not divisible");
    }
}