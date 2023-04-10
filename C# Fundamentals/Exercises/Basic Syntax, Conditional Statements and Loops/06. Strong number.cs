using System;
public class Program
{
    public static void Main()
    {
        string num = Console.ReadLine();
        int sum = 0;
        foreach(char c in num)
        {
            sum += GetFactorial((int)char.GetNumericValue(c));
        }
        if(int.Parse(num) == sum)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
    public static int GetFactorial(int num)
    {//uncreative exercise:(
        if(num == 0)
        {
            return 1;
        }
        int result = num;
        for(int n = num - 1; n >= 1;--n)
        {
            result *= n;
        }
        return result;
    }
}