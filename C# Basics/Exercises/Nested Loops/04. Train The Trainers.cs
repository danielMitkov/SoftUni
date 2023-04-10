using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int gradeCount = int.Parse(Console.ReadLine());
            string prese = Console.ReadLine();
            double avgFinal = 0;
            int counter = 0;
            while (prese != "Finish") {
                double avgLocal = 0;
                for (int g = gradeCount; g > 0; --g) { 
                    avgLocal += double.Parse(Console.ReadLine());
                }
                avgLocal = avgLocal / gradeCount;
                Console.WriteLine($"{prese} - {avgLocal:f2}.");
                avgFinal += avgLocal;
                prese = Console.ReadLine();
                counter++;
            }
            avgFinal = avgFinal / counter;
            Console.WriteLine($"Student's final assessment is {avgFinal:f2}.");
        }
    }
}