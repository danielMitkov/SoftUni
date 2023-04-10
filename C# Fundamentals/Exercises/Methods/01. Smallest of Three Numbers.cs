using System;
using System.Linq;
namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3];
            for(int i =0; i<3;i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int min = Smallest(array);
            Console.WriteLine(min);
        }
        static int Smallest(int[] array)
        {
            int min = array.Min();
            return min;

        }
    }
}