using System;
namespace app{
    internal class Program{
        static void Main(string[] args){
            double skumriaCost = double.Parse(Console.ReadLine());
            double cacaCost = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            double midiKg = double.Parse(Console.ReadLine());

            double palamudPrice = skumriaCost + (skumriaCost * 0.6);
            double palamudSum = palamudKg * palamudPrice;

            double safridPrice = cacaCost + (cacaCost * 0.8);
            double safridSum = safridKg * safridPrice;

            double midiSum = midiKg * 7.5;

            Console.WriteLine(String.Format("{0:0.00}",palamudSum+safridSum+midiSum));
        }
    }
}