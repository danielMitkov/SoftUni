using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int badGrades = int.Parse(Console.ReadLine());
            double sum = 0;
            int counter = 0;
            int badGradesCounter = 0;
            string lastProblem = "";
            string nameOfProblem = Console.ReadLine();
            while (nameOfProblem != "Enough") {
                int grade = int.Parse(Console.ReadLine());
                lastProblem = nameOfProblem;
                if (grade <= 4) {
                    badGradesCounter++;
                    if (badGradesCounter == badGrades) {
                        Console.WriteLine($"You need a break, {badGradesCounter} poor grades.");
                        break;
                    }
                }
                sum += grade;
                counter++;
                nameOfProblem = Console.ReadLine();
            }
            if (badGradesCounter < badGrades) {
                Console.WriteLine($"Average score: {(sum / counter):F2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}