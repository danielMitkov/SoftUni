using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int start = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int first = start; first <= stop; ++first) {
                for (int second = start; second <= stop; ++second) {
                    counter++;
                    if (first + second == magic) {
                        Console.WriteLine($"Combination N:{counter} ({first} + {second} = {magic})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magic}");
        }
    }
}