using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int floor = int.Parse(Console.ReadLine());
            int room = int.Parse(Console.ReadLine());
            for (int f = floor; f > 0; --f) {
                int counter = 0;
                for (int r = room; r > 0; --r) {
                    if (f == floor) {
                        Console.Write($"L{f * 10 + counter} ");
                    } else if (f % 2 == 0) {
                        Console.Write($"O{f * 10 + counter} ");
                    } else {
                        Console.Write($"A{f * 10 + counter} ");
                    }
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }
}