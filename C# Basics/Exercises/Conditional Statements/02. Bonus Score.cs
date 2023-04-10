using System;
class Program
{
    static void Main()
    {
        double num = double.Parse(Console.ReadLine());
        double bonus;
        if(num <= 100)
        {
            bonus = 5;
        }
        else if(num > 1000)
        {
            bonus = num * 0.1;
        }
        else
        {
            bonus = num * 0.2;
        }
        if(num % 2 == 0)
        {
            bonus += 1;
        }
        if(num % 10 == 5)
        {
            bonus += 2;
        }
        Console.WriteLine(bonus);
        Console.WriteLine(num + bonus);
    }
}