using System;
public class Program
{
    public static void Main()
    {
        string user = Console.ReadLine();
        for(int n = 1;n <= 4;++n)
        {
            char[] pass = Console.ReadLine().ToCharArray();
            Array.Reverse(pass);
            if(new string(pass) == user)
            {
                Console.Write($"User {user} logged in.");
                return;
            }
            else if(n < 4)
            {
                Console.WriteLine("Incorrect password. Try again.");
            }
        }
        Console.Write($"User {user} blocked!");
    }
}