using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            string nameActor = Console.ReadLine();
            double pointsAcademy = double.Parse(Console.ReadLine());
            int countJury = int.Parse(Console.ReadLine());
            string nameJury = "";
            double pointsJury = 0;
            double pointsAll = pointsAcademy;
            for (int i = 1; i <= countJury; i++) { 
                nameJury = Console.ReadLine();
                pointsJury = double.Parse(Console.ReadLine());
                pointsAll += (nameJury.Length * pointsJury) / 2;
                if (pointsAll >= 1250.5) {
                    Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {pointsAll:F1}!");
                    return;
                }
            }
            Console.WriteLine($"Sorry, {nameActor} you need {(1250.5 - pointsAll):F1} more!");
        }
    }
}