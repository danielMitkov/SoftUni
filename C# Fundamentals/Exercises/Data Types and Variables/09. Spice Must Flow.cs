using System;
namespace SoftUni
{
    public class Program
    {
        static void Main(string[] args)
        {
            int startingYeild = int.Parse(Console.ReadLine());
            int days = 0;
            int total = 0;
            while(startingYeild >= 100) {
                days++;
                total += startingYeild;
                total -= 26;
                startingYeild -= 10;
            }
            if (total >= 26){
                total -= 26;
            } 
            Console.WriteLine(days);
            Console.WriteLine(total);
        }
    }
}