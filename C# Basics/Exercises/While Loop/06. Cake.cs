using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int horizon = int.Parse(Console.ReadLine());
            int vertical = int.Parse(Console.ReadLine());
            int pieces = horizon * vertical;
            while (pieces > 0) {
                string input = Console.ReadLine();
                if (input == "STOP") {
                    Console.WriteLine($"{pieces} pieces are left.");
                    return;
                }
                pieces -= int.Parse(input);
            }
            Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
        }
    }
}