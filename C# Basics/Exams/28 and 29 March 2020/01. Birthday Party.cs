using System;
public class Program
{
    public static void Main()
    {
        double cost = double.Parse(Console.ReadLine());
        double cake = cost * 0.2;
        double drinks = cake - cake * 0.45;
        double animator = cost / 3;
        cost += cake + drinks + animator;
        Console.WriteLine(cost);
    }
}