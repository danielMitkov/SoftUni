using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Stack<int> tasks = new Stack<int>(Console.ReadLine()
            .Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        int toKill = int.Parse(Console.ReadLine());
        while(true)
        {
            int thread = threads.Peek();
            int task = tasks.Peek();
            if(task == toKill)
            {
                Console.WriteLine($"Thread with value {thread} killed task {toKill}");
                Console.WriteLine(string.Join(" ",threads));
                return;
            }
            if(thread >= task)
            {
                threads.Dequeue();
                tasks.Pop();
            }
            if(thread < task)
            {
                threads.Dequeue();
            }
        }
    }
}
