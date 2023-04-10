using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string show = Console.ReadLine();
            double timeEp = double.Parse(Console.ReadLine());
            double timeRest = double.Parse(Console.ReadLine());

            timeRest -= (timeRest / 8) + (timeRest / 4);

            if (timeRest >= timeEp) {

                Console.WriteLine($"You have enough time to watch {show} and left with {Math.Ceiling(timeRest - timeEp)} minutes free time.");
            } else {
                Console.WriteLine($"You don't have enough time to watch {show}, you need {Math.Ceiling(timeEp - timeRest)} more minutes.");
            }
        }
    }
}