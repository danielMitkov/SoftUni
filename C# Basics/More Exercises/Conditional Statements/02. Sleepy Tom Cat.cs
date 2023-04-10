using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int daysOff = int.Parse(Console.ReadLine());
            int workDays = 365 - daysOff;
            int playTime = workDays * 63 + daysOff * 127;
            int diff = Math.Abs(30000 - playTime);

            if (playTime > 30000) {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{diff / 60} hours and {diff % 60} minutes more for play");
            } else {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{diff / 60} hours and {diff % 60} minutes less for play");
            }
        }
    }
}