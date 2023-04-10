using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double chapionships = double.Parse(Console.ReadLine());
            double pointsInitial = double.Parse(Console.ReadLine());
            double points = 0;
            double wins = 0;
            for (int i = 1; i <= chapionships; ++i) {
                switch (Console.ReadLine()) {
                    case "W":
                        points += 2000;
                        wins++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }
            Console.WriteLine($"Final points: {points + pointsInitial}");
            Console.WriteLine($"Average points: {Math.Floor(points / chapionships)}");
            Console.WriteLine($"{((wins / chapionships) * 100):F2}%");
        }
    }
}