using System;
namespace SoftUni {
    internal class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            double avg = 0;
            string lows = "";
            double lowi = double.MaxValue;
            string highs = "";
            double highi = double.MinValue;
            for (int i = 1; i <= n; ++i) {
                string film = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                if (rating < lowi) {
                    lowi = rating;
                    lows = film;
                }
                if (rating > highi) {
                    highi = rating;
                    highs = film;
                }
                avg += rating;
            }
            Console.WriteLine($"{highs} is with highest rating: {highi:f1}");
            Console.WriteLine($"{lows} is with lowest rating: {lowi:f1}");
            Console.WriteLine($"Average rating: {avg / n:f1}");
        }
    }
}