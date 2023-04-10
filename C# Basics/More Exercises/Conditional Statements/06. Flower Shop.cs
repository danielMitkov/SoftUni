using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            double magnolii = double.Parse(Console.ReadLine()) * 3.25;
            double zumbuli = double.Parse(Console.ReadLine()) * 4;
            double rozi = double.Parse(Console.ReadLine()) * 3.5;
            double kaktusi = double.Parse(Console.ReadLine()) * 8;
            double giftPrice = double.Parse(Console.ReadLine());
            double sum = magnolii + zumbuli + rozi + kaktusi;
            sum -= sum * 0.05;
            if (sum >= giftPrice) {
                Console.WriteLine($"She is left with {(int)(sum - giftPrice)} leva.");
            } else {
                Console.WriteLine($"She will have to borrow {(int)Math.Ceiling(giftPrice - sum)} leva.");
            }
        }
    }
}