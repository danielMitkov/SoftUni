namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var scarfs = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var sets = new List<int>();
            while(hats.Any() && scarfs.Any())
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                if(hat > scarf)
                {
                    sets.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                if(scarf > hat)
                {
                    hats.Pop();
                }
                if(hat == scarf)
                {
                    scarfs.Dequeue();
                    hat++;
                    hats.Pop();
                    hats.Push(hat);
                }
            }
            int expensive = sets.Max();
            Console.WriteLine($"The most expensive set is: {expensive}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
