using System;
public class Program
{
    public static void Main()
    {
        int age = int.Parse(Console.ReadLine());
        if(age <= 2)
        {
            Console.Write("baby");
        }
        else if(age <= 13)
        {
            Console.Write("child");
        }
        else if(age <= 19)
        {
            Console.Write("teenager");
        }
        else if(age <= 65)
        {
            Console.Write("adult");
        }
        else
        {
            Console.Write("elder");
        }
    }
}