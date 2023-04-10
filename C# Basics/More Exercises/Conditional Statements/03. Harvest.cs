using System;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapes = double.Parse(Console.ReadLine());
            int needLitreWine = int.Parse(Console.ReadLine());
            int numberWorkers = int.Parse(Console.ReadLine());

            double grapesNeedForOneLitreGRapes = 2.5;
            double totalGrapes = area * grapes;
            double wine = (totalGrapes * 0.40) / grapesNeedForOneLitreGRapes;
if (wine >= needLitreWine)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                double leftWine = wine - needLitreWine;
                double wineForOneWorker = leftWine / numberWorkers;
                Console.WriteLine($"{Math.Ceiling(leftWine)} liters left -> {Math.Ceiling(wineForOneWorker)} liters per person.");

            }
            else if (wine < needLitreWine)
            {
                double needWineSum = needLitreWine - wine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(needWineSum)} liters wine needed.");
            }
        }
    }
}