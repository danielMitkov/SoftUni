using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double recordSec = double.Parse(Console.ReadLine());
            double distanceM = double.Parse(Console.ReadLine());
            double timeSec1M = double.Parse(Console.ReadLine());

            double hisSec = distanceM * timeSec1M;

            hisSec += Math.Floor(distanceM / 15) * 12.5;

            if (hisSec < recordSec) {

                Console.WriteLine($" Yes, he succeeded! The new world record is {hisSec:F2} seconds.");
            } else {
                Console.WriteLine($"No, he failed! He was {Math.Abs(recordSec - hisSec):F2} seconds slower.");
            }
        }
    }
}